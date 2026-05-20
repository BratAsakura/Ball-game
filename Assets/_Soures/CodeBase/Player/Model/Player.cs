using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(UniversalInputSystem))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 3;

    private PlayerMovement _movement;
    private IInputSystem _input;

    public void TakeDamage()
    {
        _health--;
    }

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _movement.SetInput(_input);
    }
}