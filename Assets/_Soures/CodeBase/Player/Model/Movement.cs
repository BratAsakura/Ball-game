using UnityEngine;

public class Movement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 4;

    public void Move(float direction)
    {
        transform.Translate(new Vector2(direction * _speed * Time.deltaTime, 0));
    }

    public void StopMove()
    {
        transform.Translate(new Vector2(0, 0));
    }
}
