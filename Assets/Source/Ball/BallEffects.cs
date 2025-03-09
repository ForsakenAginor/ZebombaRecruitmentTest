using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallEffects : MonoBehaviour
{
    private const string DissolveValue = "_DissolveValue";

    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _disablingTime = 0.7f;

    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private Action<GameObject> _onDisableCallback;
    private Material _material;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = new Material(_spriteRenderer.material);
        _spriteRenderer.material = _material;
    }

    public void Init(Color color, Action<GameObject> onDisableCallback)
    {
        _color = color;
        _spriteRenderer.color = color;
        _onDisableCallback = onDisableCallback;
    }

    public void PlayEffect()
    {
        StartCoroutine(Disabling());
    }

    private IEnumerator Disabling()
    {
        WaitForSeconds delay = new WaitForSeconds(_disablingTime/2);
        _material.DOFloat(0, DissolveValue, _disablingTime);
        yield return delay;
        var effect = Instantiate(_effect, transform.position, transform.rotation);
        effect.startColor = _color;
        yield return delay;
        _onDisableCallback?.Invoke(gameObject);
        gameObject.SetActive(false);
        _material.SetFloat(DissolveValue, 1f);

    }
}
