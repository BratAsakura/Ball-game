using TMPro;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _scoreView;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _healthView;

    private void Start()
    {
        _healthView.SetText($"Health: {_player.Health}");
    }

    private void OnEnable()
    {
        _scoreManager.ScoreChange += OnScoreChange;
        _player.HealthChanged += OnHealthChange;
    }

    private void OnHealthChange(int value)
    {
        _healthView.SetText($"Health: {value}");
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.HealthChanged -= OnScoreChange;

        if (_scoreManager != null)
            _scoreManager.ScoreChange -= OnHealthChange;
    }

    private void OnScoreChange(int value)
    {
        _scoreView.SetText($"Score: {value}");
    }
}
