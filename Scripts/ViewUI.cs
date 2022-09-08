using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ViewUI : MonoBehaviour
{
    [SerializeField]
    private Button _ageButton;

    [SerializeField]
    private Button _slowMotionButton;

    [SerializeField]
    private TextMeshProUGUI _bitcoinValue;

    public void AddListenerAgeButton(UnityAction action)
    {
        _ageButton.onClick.AddListener(action);
    }

    public void AddListenerSlowMotionButton(UnityAction action)
    {
        _slowMotionButton.onClick.AddListener(action);
    }

    internal void UpdateBitcoinValue(int value)
    {
        _bitcoinValue.text = value.ToString();
    }
}