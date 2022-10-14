using UnityEngine;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private LocationGenerator _locationGenerator;

    [SerializeField]
    private ViewUI _viewUI;

    [SerializeField] 
    private PlayerInput _playerInput;

    [SerializeField]
    private PlayerDataHandler _playerDataHandler;

    private readonly ExchangeRateGenerator _exchangeRateGenerator = new ExchangeRateGenerator();

    private void Start()
    {
        Restart();
    }

    public void TradeChoiceEntered()
    {
        _exchangeRateGenerator.Generate();
        _viewUI.ShowTradeUI(_exchangeRateGenerator.GetRate(), SaveBitcoin, TradeBitcoin);
    }

    public void FinishEntered()
    {
        _viewUI.OpenFinishMenu(_playerDataHandler.GetMoney(), _playerDataHandler.GetSavedBit(), Restart);
    }

    private void Restart()
    {
        _locationGenerator.SpawnLocations();
        _playerInput.Restart();
        _playerDataHandler.Restart();
        _viewUI.OpenStartMenu(_playerInput.Move);
    }

    private void SaveBitcoin()
    {
        _playerDataHandler.SaveBit();
        _playerInput.Move();
    }

    private void TradeBitcoin()
    {
        _playerDataHandler.TradeBit(_exchangeRateGenerator.GetRate());
        _playerInput.Move();
    }
}

