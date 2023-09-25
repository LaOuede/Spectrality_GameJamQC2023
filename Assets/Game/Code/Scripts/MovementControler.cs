using UnityEngine;

public class MovementControler : MonoBehaviour
{
    public Vector2 MoveInput;
    public Rigidbody _rb;
    public float Speed = 8;
    public float RotationSpeed = 90;

    private Vector3 _direction;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (_direction.magnitude != 0)
        {
            _rb.rotation = Quaternion.RotateTowards(_rb.rotation, Quaternion.LookRotation(_direction, Vector3.up), RotationSpeed * Time.deltaTime);
        }
    }

    void HandleMovement()
    {
        _direction = new Vector3(MoveInput.x, 0, MoveInput.y);

        Vector3 desiredVelocity = _direction * Speed;

        _rb.velocity = desiredVelocity;
    }
}
