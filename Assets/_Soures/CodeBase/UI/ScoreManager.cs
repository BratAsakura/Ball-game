using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;

    private int _value;

    public event Action<int> ScoreChange;

    private void Awake()
    {
        foreach (Coin coin in _coins)
            coin.Collection += AddScore;
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
            coin.Collection -= AddScore;
    }

    private void AddScore(int value)
    {
        _value += value;
        ScoreChange?.Invoke(_value);
    }
}
