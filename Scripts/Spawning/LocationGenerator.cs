using UnityEngine;
public class LocationGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _spawnPoints;
    [SerializeField]
    private LocationsPool _locationsPool;
    public void SpawnLocations()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _locationsPool.GetLocation(Generate(), _spawnPoints[i]);
        }
    }

    private LocationType Generate()
    {
        return (LocationType) Random.Range(0, (int)LocationType.Length);
    }
}

