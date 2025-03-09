using System;
using UnityEngine;

[RequireComponent(typeof(Ball))]
[RequireComponent(typeof(BallEffects))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallFacade : MonoBehaviour
{
    private Ball _ball;
    private BallEffects _ballEffects;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
        _ballEffects = GetComponent<BallEffects>();
    }

    public void Init(BallColor color, Action<GameObject> onDisableCallback, Color spriteColor)
    {
        _ball.Init(color);
        _ballEffects.Init(spriteColor, onDisableCallback);
    }
}
