using Euphrates;
using UnityEngine;

public class TapBrushPosition : MonoBehaviour
{
    Transform _transform;

    [Header("Events")]
    [SerializeField] TriggerChannelSO _layerChange;
    [SerializeField] TriggerChannelSO _tapStart;
    [SerializeField] TriggerChannelSO _tapEnd;

    [Space]
    [SerializeField] Transform _plate;
    [SerializeField] DrawDataSO _drawingData;

    [Space]
    [Header("Tap Animation")]
    [SerializeField] Transform _brush;
    [SerializeField] float _upPos;
    [SerializeField] float _downPos;
    [SerializeField] float _duration;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _layerChange.AddListener(SetPosition);
        SetPosition();

        _tapStart.AddListener(OnTapStart);
        _tapEnd.AddListener(OnTapEnd);
    }

    private void OnDisable()
    {
        _layerChange.RemoveListener(SetPosition);

        _tapStart.RemoveListener(OnTapStart);
        _tapEnd.RemoveListener(OnTapEnd);
    }

    void SetPosition() => _transform.localPosition 
        = new Vector3(_transform.localPosition.x, 
        _transform.localPosition.y, 
        _drawingData.CurrentLayer.Data1);

    void OnTapStart()
    {
        Tween.DoTween(_brush.localPosition, new Vector3(_brush.localPosition.x, _downPos, _brush.localPosition.z), _duration, Ease.OutCirc, p => _brush.localPosition = p);
    }

    void OnTapEnd()
    {
        Tween.DoTween(_brush.localPosition, new Vector3(_brush.localPosition.x, _upPos, _brush.localPosition.z), _duration, Ease.OutCirc, p => _brush.localPosition = p);
    }
}
