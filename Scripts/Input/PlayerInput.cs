using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick _joystick;

    public bool IsMoving { get; private set; } = true;

    public bool IsJumping = false;

    public float Horizontal { get; private set; } = 0f;

    private void FixedUpdate()
    {
        Horizontal = _joystick.Horizontal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out StopLine _))
            IsMoving = false;
    }

}