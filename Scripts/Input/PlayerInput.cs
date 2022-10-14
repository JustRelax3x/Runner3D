using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick _joystick;

    public bool IsMoving { get; private set; } = true;

    public bool IsJumping = false;

    public float Horizontal { get; private set; } = 0f;


    public void Move()
    {
        IsMoving = true;
    }

    public void Restart()
    {
        IsMoving = false;
    }

    public void Stop()
    {
        IsMoving = false;
    }

    private void FixedUpdate()
    {
        Horizontal = _joystick.Horizontal;
    }

}