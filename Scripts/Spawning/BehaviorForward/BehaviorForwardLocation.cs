using UnityEngine;
public class BehaviorForwardLocation : BehaviorLocation
{
    [SerializeField]
    private LocationType _locationType;
    [SerializeField]
    private int _behaviorQuantity = 1;
    public override LocationType GetLocationType() => _locationType;

    private const float _maxOffset = 9f, _minOffset = 2f;

    private Behavior[] _behavior;

    private void Start()
    {
        if (_behaviorQuantity <= 0) _behaviorQuantity = 1;
        _behavior = new Behavior[_behaviorQuantity];
    }
    private void SpawnBehavior(Vector3 targetPos)
    {
        float offsetX = Random.Range(-_maxOffset, _maxOffset);
        float offsetZ = (transform.position.z - targetPos.z) / 2f;
        Vector3 offset = new Vector3(offsetX, 0, offsetZ); 
        Vector3 destination = transform.position;
        destination.z -= 5 * offsetZ;
        for (int i = 0; i < _behaviorQuantity; i++)
        {
            Behavior behavior = _behaviorPool.GetBehavior(transform.position + offset);
            behavior.transform.LookAt(destination);
            _behavior[i] = behavior;
            offsetX = Random.Range(_minOffset, _maxOffset);
            offset.x += offsetX;
            if (offset.x > _maxOffset) offset.x -= 2 * _maxOffset;
        }
    }

    public override void Recycle()
    {
        foreach (var b in _behavior) b.Recycle();
        _pool.ReturnToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController _))
            SpawnBehavior(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CharacterController _))
            Recycle();
    }
}