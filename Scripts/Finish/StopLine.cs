public class StopLine : Line
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.TryGetComponent(out PlayerInput playerInput))
            playerInput.Stop();
    }
}
