using UnityEngine;

public class BehaviorForward : Behavior
{
    [SerializeField]
    private Vector3 _speed = new Vector3(0, 0, 0.8f);
    [SerializeField]
    private bool _isActiveAfterCollision = true;

    private void FixedUpdate()
    {
        transform.Translate(_speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerDataHandler abilityHandler)) return;
        abilityHandler.DamagePlayer(damageDivisionCoefficient);
        if (!_isActiveAfterCollision) gameObject.SetActive(false); 
    }
}