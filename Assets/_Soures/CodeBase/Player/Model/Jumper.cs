using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour, ICanJump
{
    [SerializeField] private float _jumpForce = 3;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        _rigidbody.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }
}
