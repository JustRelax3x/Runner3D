using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _speed = new Vector3(0, 0, 0.7f);

    private void Update()
    {
        transform.Translate(_speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<AbilityHandler>(out AbilityHandler abilityHandler)) return;
        abilityHandler.DamagePlayer();
    }
}