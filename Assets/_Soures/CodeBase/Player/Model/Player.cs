using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(UniversalInputSystem))]
public class Player : MonoBehaviour
{
    private PlayerMovement _movement;
    private IInputSystem _input;

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _movement.SetInput(_input);
    }
}
