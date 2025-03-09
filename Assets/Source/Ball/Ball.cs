using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private BallColor _color;

    private Action<GameObject> _onDisableCallback;

    public BallColor Color => _color;

    private void OnDisable()
    {
        _onDisableCallback?.Invoke(gameObject);
    }

    public void Init(BallColor color, Action<GameObject> onDisableCallback)
    {
        _color = color;
        _onDisableCallback = onDisableCallback;
    }
}
