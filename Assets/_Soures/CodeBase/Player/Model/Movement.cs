using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 4;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);
    }

    public void StopMove()
    {
        _rigidbody.linearVelocity = new Vector2(0f, _rigidbody.linearVelocity.y);
    }
}