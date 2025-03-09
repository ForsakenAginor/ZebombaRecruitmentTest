using System;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _joint;

    public event Action JointBroke;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _joint.connectedBody = null;
            JointBroke?.Invoke();
        }
    }
}
