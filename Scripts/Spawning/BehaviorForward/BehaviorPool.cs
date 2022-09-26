using System.Collections.Generic;
using UnityEngine;

public class BehaviorPool : MonoBehaviour, IPool
{
    [SerializeField]
    private BehaviorForward _behaviorPrefab;

    private readonly Queue<BehaviorForward> _behaviorPool = new Queue<BehaviorForward>(3);

    private BehaviorForward CreateBehavior()
    {
        var behavior = Instantiate(_behaviorPrefab, transform, false);
        behavior.SetPool(this);
        behavior.gameObject.SetActive(false);
        return behavior;
    }

    public BehaviorForward GetBehavior(Vector3 position)
    {
        BehaviorForward result = _behaviorPool.Count == 0 ? CreateBehavior() : _behaviorPool.Dequeue();

        result.gameObject.SetActive(true);
        result.transform.position = position;
        return result;
    }

    public void ReturnBehavior(BehaviorForward behavior)
    {
        behavior.transform.position = new Vector3(-100, behavior.transform.position.y, -10);
        behavior.gameObject.SetActive(false);
        _behaviorPool.Enqueue(behavior);
    }

    public void ReturnToPool(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out BehaviorForward behavior))
            ReturnBehavior(behavior);
    }
}