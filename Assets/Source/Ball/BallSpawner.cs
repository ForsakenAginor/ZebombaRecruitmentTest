using System;
using UnityEngine;

public class BallSpawner
{
    private readonly HingeJoint2D _joint;
    private readonly BallLauncher _launcher;
    private readonly Vector3 _spawnPoint;
    private readonly BallPool _pool;

    public BallSpawner(HingeJoint2D joint, BallLauncher launcher, Vector3 spawnPoint, BallPool pool)
    {
        _joint = joint != null ? joint : throw new ArgumentNullException(nameof(joint));
        _launcher = launcher != null ? launcher : throw new ArgumentNullException(nameof(launcher));
        _pool = pool != null ? pool : throw new ArgumentNullException(nameof(pool));
        _spawnPoint = spawnPoint;

        OnJointBroke();
        _launcher.JointBroke += OnJointBroke;
    }

    ~BallSpawner()
    {
        _launcher.JointBroke -= OnJointBroke;
    }

    private void OnJointBroke()
    {
        var ball = _pool.GetBall();
        ball.transform.position = _spawnPoint;
        _joint.connectedBody = ball;
    }
}
