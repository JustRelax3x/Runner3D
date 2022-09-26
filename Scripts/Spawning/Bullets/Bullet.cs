using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _speed = new Vector3(0, 0, 0.7f);

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
        if (!other.TryGetComponent<AbilityHandler>(out AbilityHandler abilityHandler)) return;
        abilityHandler.DamagePlayer();
    }
}