using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ViewUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bitcoinValue;

    [SerializeField]
    private TradeUI _tradeUI;

    [SerializeField]
    private FinishUI _finishUI;

    [SerializeField]
    private MenuUI _menuUI;

    internal void UpdateBitcoinValue()
    {
        _bitcoinValue.text = PlayerData.CurrentBitcoin.ToString();
    }

    internal void OpenStartMenu(UnityAction openMenu)
    {
        _menuUI.Open(openMenu);
    }

    internal void OpenFinishMenu(int money, int savedBit, UnityAction openMenu)
    {
        _finishUI.Open(money,savedBit,openMenu);
    }

    internal void ShowTradeUI(int exchangeRate, UnityAction Save, UnityAction Trade)
    {
        _tradeUI.Open(exchangeRate, Save, Trade);
    }
}