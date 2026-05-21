using TMPro;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreView;
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private MonoBehaviour _scoreProvider;
    [SerializeField] private MonoBehaviour _healthProvider;
    [SerializeField] private MonoBehaviour _finishProvider;
    [SerializeField] private GameObject _windowFinish;

    private IScoreProvider _scoreProviderInterface;
    private IHealthProvider _healthProviderInterface;
    private IFinishProvider _finishProviderInterface;

    private void Awake()
    {
        _windowFinish.SetActive(false);
        _scoreProviderInterface = (IScoreProvider)_scoreProvider;
        _healthProviderInterface = (IHealthProvider)_healthProvider;
        _finishProviderInterface = (IFinishProvider)_finishProvider;
    }

    private void OnEnable()
    {
        _scoreProviderInterface.ScoreChange += OnScoreChange;
        _healthProviderInterface.HealthChanged += OnHealthChange;
        _finishProviderInterface.OnFinished += OnFinishView;
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

        if (_finishProviderInterface != null)
            _finishProviderInterface.OnFinished -= OnFinishView;
    }

    private void OnHealthChange(int value)
    {
        _healthView.SetText($"Health: {value}");
    }

    private void OnScoreChange(int value)
    {
        _scoreView.SetText($"Score: {value}");
    }

    private void OnFinishView()
    {
        _windowFinish.SetActive(true);
    }
}