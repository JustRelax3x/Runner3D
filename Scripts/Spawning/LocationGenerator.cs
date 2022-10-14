using System;
using UnityEngine;
public class LocationGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _spawnPoints;
    [SerializeField]
    private SpawnData[] _gatesPoints;
    [SerializeField]
    private LocationsPool _locationsPool;
    [SerializeField]
    private GatesPool _gatesPool;
    public void SpawnLocations()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _locationsPool.GetLocation(Generate(), _spawnPoints[i]);
        }
        for (int i=0; i < _gatesPoints.Length; i++)
        {
            _gatesPool.GetGates(_gatesPoints[i].IsPositive, _gatesPoints[i].Position).Generate();
        }
    }

    private LocationType Generate()
    {
        return (LocationType) UnityEngine.Random.Range(0, _locationsPool.Count());
    }

    [Serializable]
    private struct SpawnData
    {
        public Vector3 Position;
        public bool IsPositive;
    }
}

