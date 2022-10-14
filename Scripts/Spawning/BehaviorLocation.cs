using UnityEngine;
[RequireComponent(typeof(Collider))]
public abstract class BehaviorLocation : MonoBehaviour
{
    protected IPool _pool;

    protected BehaviorPool _behaviorPool;

    public void SetLocationPool(IPool pool)
    {
        _pool = pool;
    }

    public void SetBehaviorPool(BehaviorPool pool)
    {
        _behaviorPool = pool;
    }
    public abstract LocationType GetLocationType();
    public abstract void Recycle();
}