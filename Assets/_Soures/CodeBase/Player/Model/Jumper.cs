using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour, ICanJump
{
    private const int DefaultJumpingCount = 1;

    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private int _jumpCount = DefaultJumpingCount;
    [SerializeField] private Transform _feets;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsGrounded() == true)
            _jumpCount = DefaultJumpingCount;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_feets.position, Vector2.down, 0.1f, _groundLayer);
        return hit.collider != null;
    }

    public void Jump()
    {
        if (IsGrounded() == false && _jumpCount == 0)
            return;

        _rigidbody.AddForceY(_jumpForce, ForceMode2D.Impulse);
        _jumpCount--;
    }
}
