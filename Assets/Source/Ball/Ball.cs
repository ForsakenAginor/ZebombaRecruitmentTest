using UnityEngine;

[RequireComponent (typeof(BallEffects))]
public class Ball : MonoBehaviour
{
    private BallEffects _effect;
    private BallColor _color;

    public BallColor Color => _color;

    private void Awake()
    {
        _effect = GetComponent<BallEffects>();
    }

    public void Init(BallColor color)
    {
        _color = color;
    }

    public void Disable()
    {
        _effect.PlayEffect();
    }
}
