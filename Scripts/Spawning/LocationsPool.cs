using System.Collections.Generic;
using UnityEngine;
public class LocationsPool : MonoBehaviour, IPool
{
    [SerializeField]
    private BehaviorLocation[] _locationsPrefab;

    [SerializeField]
    private BehaviorPool[] _behaviorsPools; 

    private readonly Queue<BehaviorLocation> _bulletsLocationPool = new Queue<BehaviorLocation>(2);
    private readonly Queue<BehaviorLocation> _carLocationPool = new Queue<BehaviorLocation>(2);
    private readonly Queue<BehaviorLocation> _manHoleLocationPool = new Queue<BehaviorLocation>(2);

    public int Count() => _locationsPrefab.Length;

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
        location.SetBehaviorPool(_behaviorsPools[(int)loc]);
        location.SetLocationPool(this);
        location.gameObject.SetActive(false);
        return location;
    }

    private Queue<BehaviorLocation> GetPool(LocationType location)
    {
        switch (location)
        {
            case LocationType.Bullet:
                return _bulletsLocationPool;
            case LocationType.Car:
                return _carLocationPool;
            case LocationType.ManHole:
                return _manHoleLocationPool;
            case LocationType.Length:
                Debug.LogError("Prohibited Usage");
                break;
        }
        return _bulletsLocationPool;
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
    ManHole = 2,
    Length,
}