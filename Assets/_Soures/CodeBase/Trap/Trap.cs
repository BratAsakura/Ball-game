using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (collision.rigidbody == null)
            return;

        if (collision.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            Damage(damageable);

        float directionX = Mathf.Sign(collision.transform.position.x - transform.position.x);
        Vector2 direction = new Vector2(directionX, 0f);

        collision.rigidbody.linearVelocity = Vector2.zero;
        collision.rigidbody.AddForce(
            direction * _force,
            ForceMode2D.Impulse);

    }

    private void Damage(IDamageable target)
    {
        target.TakeDamage();
    }
}
