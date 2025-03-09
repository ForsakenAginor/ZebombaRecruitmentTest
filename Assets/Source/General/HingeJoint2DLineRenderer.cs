using UnityEngine;

public class HingeJoint2DLineRenderer : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _hingeJoint;
    [SerializeField] private LineRenderer _lineRenderer;

    [Header("LineParameters")]
    [SerializeField] private float _width = 0.1f;
    [SerializeField] private Color _color = Color.black;

    private void Start()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = _width;
        _lineRenderer.endWidth = _width;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.startColor = _color;
        _lineRenderer.endColor = _color;
    }

    private void LateUpdate()
    {
        if (_hingeJoint.connectedBody == null)
            return;

        _lineRenderer.SetPosition(0, _hingeJoint.transform.position);
        _lineRenderer.SetPosition(1, _hingeJoint.connectedBody.transform.position);
    }
}
