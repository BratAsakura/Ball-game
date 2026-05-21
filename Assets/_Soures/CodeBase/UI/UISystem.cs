using TMPro;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreView;
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private MonoBehaviour _scoreProvider;
    [SerializeField] private MonoBehaviour _healthProvider;

    private IScoreProvider _scoreProviderInterface;
    private IHealthProvider _healthProviderInterface;

    private void Awake()
    {
        _scoreProviderInterface = (IScoreProvider)_scoreProvider;
        _healthProviderInterface = (IHealthProvider)_healthProvider;
    }

    private void OnEnable()
    {
        _scoreProviderInterface.ScoreChange += OnScoreChange;
        _healthProviderInterface.HealthChanged += OnHealthChange;
    }

    private void Start()
    {
        _healthView.SetText($"Health: {_healthProviderInterface.Health}");
    }

    private void OnDisable()
    {
        if (_healthProviderInterface != null)
            _healthProviderInterface.HealthChanged -= OnHealthChange;

        if (_scoreProviderInterface != null)
            _scoreProviderInterface.ScoreChange -= OnScoreChange;
    }

    private void OnHealthChange(int value)
    {
        _healthView.SetText($"Health: {value}");
    }

    private void OnScoreChange(int value)
    {
        _scoreView.SetText($"Score: {value}");
    }
}