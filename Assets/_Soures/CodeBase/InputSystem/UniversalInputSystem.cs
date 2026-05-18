using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniversalInputSystem : MonoBehaviour, IInputSystem
{
    private GameInput _gameInput;
    private Vector2 _currentDirection;

    public event Action<float> Moving;
    public event Action Jumping;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Player.Move.performed += OnMovePerformed;
        _gameInput.Player.Move.canceled += OnMoveCanceled;
        _gameInput.Player.Jump.performed += OnJump;
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void OnDestroy()
    {
        _gameInput.Player.Move.performed -= OnMovePerformed;
        _gameInput.Player.Move.canceled -= OnMoveCanceled;
        _gameInput.Player.Jump.performed -= OnJump;
    }

    private void FixedUpdate()
    {
        Moving?.Invoke(_currentDirection.x);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jumping?.Invoke();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _currentDirection = Vector2.zero;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _currentDirection = context.ReadValue<Vector2>();
    }
}
