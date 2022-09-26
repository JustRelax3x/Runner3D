using UnityEngine;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private LocationGenerator _locationGenerator;

    private void Start()
    {
        _locationGenerator.SpawnLocations();
    }
}

