using System;
using UnityEngine;

public class BallLauncher
{
    private readonly HingeJoint2D _joint;
    private readonly PlayerInput _playerInput;

    public event Action JointBroke;

    public BallLauncher(PlayerInput input, HingeJoint2D joint)
    {
        _playerInput = input != null ? input : throw new ArgumentNullException(nameof(input));
        _joint = joint != null ? joint : throw new ArgumentNullException(nameof(joint));

        _playerInput.ClickInputReceived += OnInputReceived;
    }

    ~BallLauncher()
    {
        _playerInput.ClickInputReceived -= OnInputReceived;
    }

    private void OnInputReceived()
    {
        _joint.connectedBody = null;
        JointBroke?.Invoke();
    }
}
