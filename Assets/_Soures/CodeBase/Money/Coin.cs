using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _score = 100;

    public event Action<int> Collection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Collection?.Invoke(_score);
    }
}
