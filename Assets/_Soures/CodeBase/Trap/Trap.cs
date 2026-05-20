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

        Vector2 direction = (collision.transform.position - transform.forward).normalized;
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
