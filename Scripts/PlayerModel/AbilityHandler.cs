using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField]
    private ViewUI _viewUI;

    private PlayerData _playerData = new PlayerData();

    public void SetCurrentBitcoin(int value)
    {
        if (value < 1) value = 1;
        _playerData.SetCurrentBitcoin(value);
        _viewUI.UpdateBitcoinValue(value);
    }

    public void DamagePlayer(int damageDivisionCoefficient)
    {
        SetCurrentBitcoin(PlayerData.CurrentBitcoin / damageDivisionCoefficient);
    }
}