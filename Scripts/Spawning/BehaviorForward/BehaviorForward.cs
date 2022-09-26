using UnityEngine;

public class BehaviorForward : MonoBehaviour
{
    [SerializeField]
    private int damageDivisionCoefficient = 3;
    private readonly Vector3 _speed = new Vector3(0, 0, 0.8f);

    private IPool _pool;

    private void Update()
    {
        transform.Translate(_speed, Space.Self);
    }

    public void SetPool(IPool pool)
    {
        _pool = pool;
    }

    public void Recycle()
    {
        _pool.ReturnToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out AbilityHandler abilityHandler)) return;
        abilityHandler.DamagePlayer(damageDivisionCoefficient);
        gameObject.SetActive(false);
    }
}