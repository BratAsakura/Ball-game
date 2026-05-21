using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private void Awake()
    {
        _window.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        _window.SetActive(true);
    }
}
