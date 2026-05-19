using UnityEngine;

public class Zone : MonoBehaviour
{
    private readonly Vector2 _defaultScale = new Vector2(1, 1);
    private readonly Vector2 _shrinkScale = new Vector2(0.5f, 0.5f);

    [SerializeField] private bool _isShrink;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (!_isShrink)
            collision.transform.localScale = _defaultScale;
        else
            collision.transform.localScale = _shrinkScale;
    }
}