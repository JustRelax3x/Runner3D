using UnityEngine;
[RequireComponent(typeof(Collider))]
public abstract class BehaviorLocation : MonoBehaviour
{
    protected IPool _pool;

    public void SetPool(IPool pool)
    {
        _pool = pool;
    }
    public abstract LocationType GetLocationType();
    public abstract void Recycle();
}