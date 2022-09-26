using TMPro;
using UnityEngine;

public class ViewUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bitcoinValue;

    internal void UpdateBitcoinValue(int value)
    {
        _bitcoinValue.text = value.ToString();
    }
}