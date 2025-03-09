using System;
using UnityEngine;

[RequireComponent(typeof(Ball))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Rigidbody2D))]
public class BallFacade : MonoBehaviour
{
    private Ball _ball;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(BallColor color, Action<GameObject> onDisableCallback, Color spriteColor)
    {
        _ball.Init(color, onDisableCallback);
        _spriteRenderer.color = spriteColor;
    }
}
