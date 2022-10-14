using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OperationGates : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] _texts = new TextMeshProUGUI[2];

    [SerializeField]
    private TMP_FontAsset[] _fontAsset = new TMP_FontAsset[2];

    [SerializeField]
    private Color[] _colors = new Color[2];

    [SerializeField]
    private MeshRenderer[] _portals = new MeshRenderer[2]; 

    [SerializeField]
    private Material[] _materials = new Material[2];

    private bool _positiveOperations = true;

    private IPool _pool;

    private OperationGenerator _operationGenerator = new OperationGenerator();

    public void SetPool(IPool pool)
    {
        _pool = pool;
    }

    public void SetOperationType(bool isPositive)
    {
        _positiveOperations = isPositive;
    }
    public void Generate()
    {
        int num = _positiveOperations ? 0 : 1;
        _texts[0].font = _fontAsset[num];
        _texts[1].font = _fontAsset[num];
        _texts[0].color = _colors[num];
        _texts[1].color = _colors[num];
        _portals[0].material = _materials[num];
        _portals[1].material = _materials[num];
        _texts[0].text = "";
        _texts[1].text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerDataHandler _)) return;
        var result = _operationGenerator.GenerateOperations(_positiveOperations);
        _texts[0].text = result[0];
        _texts[1].text = result[1];
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out PlayerDataHandler abilityHandler)) return;
        int value = PlayerData.CurrentBitcoin;
        if (other.transform.position.x - transform.position.x >= 0) _operationGenerator.DoOperation(_texts[1].text, ref value);
        else _operationGenerator.DoOperation(_texts[0].text, ref value);
        abilityHandler.SetCurrentBitcoin(value);
        _pool.ReturnToPool(gameObject);
    }
}