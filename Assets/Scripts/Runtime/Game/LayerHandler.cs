using Euphrates;
using UnityEngine;

public class LayerHandler : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] TriggerChannelSO _layerChange;
    [SerializeField] TriggerChannelSO _lastLayer;
    [SerializeField] TriggerChannelSO _nextPainting;
    [Space]
    [SerializeField] DrawDataSO _drawingData;

    private void OnEnable()
    {
        _layerChange.AddListener(ChangeLayer);
        _nextPainting.AddListener(ResetLayer);
    }

    private void OnDisable()
    {
        _layerChange.RemoveListener(ChangeLayer);
        _nextPainting.RemoveListener(ResetLayer);
    }

    private void Start()
    {
        _drawingData.CurrentLayerIndex = 0;
    }

    void ChangeLayer()
    {
        _drawingData.CurrentLayerIndex++;

        if (_drawingData.CurrentLayerIndex >= _drawingData.LayerCount - 1)
            _lastLayer.Invoke();
    }

    void ResetLayer() => _drawingData.CurrentLayerIndex = 0;
}
