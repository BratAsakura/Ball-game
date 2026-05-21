using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Finish : MonoBehaviour, IFinishProvider
{
    public event Action OnFinished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        OnFinished?.Invoke();
    }
}