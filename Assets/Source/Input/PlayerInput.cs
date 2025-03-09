using System;
using UnityEngine.InputSystem;

public class PlayerInput
{
    private readonly InputSystemActions _inputSystem;

    public PlayerInput()
    {
        _inputSystem = new InputSystemActions();
        _inputSystem.Enable();
        _inputSystem.Player.Release.performed += OnInputReceived;
    }

    public event Action ClickInputReceived;

    public void Destroy()
    {
        _inputSystem.Disable();
        _inputSystem.Player.Release.performed -= OnInputReceived;
        _inputSystem.Dispose();
    }

    private void OnInputReceived(InputAction.CallbackContext context)
    {
        ClickInputReceived?.Invoke();
    }
}
