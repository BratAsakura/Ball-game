using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(UniversalInputSystem))]
public class Player : MonoBehaviour, IDamageable, IHealthProvider
{
    [SerializeField] private int _health = 3;

    private PlayerMovement _movement;
    private IInputSystem _input;

    public event Action<int> HealthChanged;

    public int Health => _health;

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _movement.SetInput(_input);
    }

    public void TakeDamage()
    {
        _health = Math.Max(0, _health - 1);
        HealthChanged?.Invoke(Health);

        if (_health == 0)
            Destroy(gameObject);
    }
}