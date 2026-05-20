using TMPro;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _scoreView;

    private void OnEnable()
    {
        _scoreManager.ScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        _scoreManager.ScoreChange -= OnScoreChange;
    }

    private void OnScoreChange(int value)
    {
        _scoreView.SetText($"Score: {value}");
    }
}
