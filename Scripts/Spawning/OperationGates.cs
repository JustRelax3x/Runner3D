using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OperationGates : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] _texts = new TextMeshProUGUI[2];

    [SerializeField]
    private bool _positiveOperations = true;

    private OperationGenerator _operationGenerator = new OperationGenerator();

    private void Start()
    {
        var result = _operationGenerator.GenerateOperations(_positiveOperations);
        _texts[0].text = result[0];
        _texts[1].text = result[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<AbilityHandler>(out AbilityHandler abilityHandler)) return;
        int value = PlayerData.CurrentBitcoin;
        if (other.transform.position.x - transform.position.x >= 0) _operationGenerator.DoOperation(_texts[1].text, ref value);
        else _operationGenerator.DoOperation(_texts[0].text, ref value);
        abilityHandler.SetCurrentBitcoin(value);
        gameObject.SetActive(false);
    }
}