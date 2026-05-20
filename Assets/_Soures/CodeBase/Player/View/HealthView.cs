using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _health;

    private void Start()
    {
        Debug.Log(_health);
        Debug.Log(_player);
        _health.SetText($"Health: {_player.Health}");
    }

    private void OnEnable()
    {
        _player.HealthChanged += SetHealth;
    }

    private void SetHealth(int value)
    {
        _health.SetText($"Health: {value}");
    }

    private void OnDisable()
    {
        _player.HealthChanged -= SetHealth;
    }
}
