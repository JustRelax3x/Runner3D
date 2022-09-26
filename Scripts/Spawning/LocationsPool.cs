using System.Collections.Generic;
using UnityEngine;
public class LocationsPool : MonoBehaviour, IPool
{
    [SerializeField]
    private BehaviorLocation[] _locationsPrefab;

    private readonly Queue<BehaviorLocation> _bulletsPool = new Queue<BehaviorLocation>(2);
    private readonly Queue<BehaviorLocation> _carPool = new Queue<BehaviorLocation>(2);

    public BehaviorLocation GetLocation(LocationType location, Vector3 position)
    {
        var pool = GetPool(location);
        BehaviorLocation result = pool.Count == 0 ? CreateLocation(location) : pool.Dequeue();
        result.gameObject.SetActive(true);
        result.transform.position = position;
        return result;
    }

    private BehaviorLocation CreateLocation(LocationType loc)
    {
        var location = Instantiate(_locationsPrefab[(int)loc], transform, true);
        location.SetPool(this);
        location.gameObject.SetActive(false);
        return location;
    }

    private Queue<BehaviorLocation> GetPool(LocationType location)
    {
        switch (location)
        {
            case LocationType.Bullet:
                return _bulletsPool;
            case LocationType.Car:
                return _carPool; 
            case LocationType.Length:
                Debug.LogError("Prohibited Usage");
                break;
        }
        return _bulletsPool;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out BehaviorLocation location)) return;
        location.gameObject.SetActive(false);
        location.transform.position = new Vector3(-100, 10, -10);
        GetPool(location.GetLocationType()).Enqueue(location);
    }
}
public enum LocationType
{
    Bullet = 0,
    Car = 1,
    Length,
}