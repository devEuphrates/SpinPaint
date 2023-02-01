using Euphrates;
using UnityEngine;

public class LayerHandler : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] TriggerChannelSO _paintMode;
    [SerializeField] TriggerChannelSO _layerChange;
    [SerializeField] TriggerChannelSO _lastLayer;
    [SerializeField] TriggerChannelSO _nextPainting;
    [Space]
    [SerializeField] DrawDataSO _drawingData;

    private void OnEnable()
    {
        _paintMode.AddListener(LayerSelected);
        _layerChange.AddListener(ChangeLayer);
        _nextPainting.AddListener(ResetLayer);
    }

    private void OnDisable()
    {
        _paintMode.RemoveListener(LayerSelected);
        _layerChange.RemoveListener(ChangeLayer);
        _nextPainting.RemoveListener(ResetLayer);
    }

    private void Start()
    {
        _drawingData.CurrentLayerIndex = 0;
    }

    void LayerSelected() => _drawingData.CurrentLayer.Selected();

    void ChangeLayer()
    {
        _drawingData.CurrentLayerIndex++;
        _drawingData.CurrentLayer.Selected();

        if (_drawingData.CurrentLayerIndex >= _drawingData.LayerCount - 1)
            _lastLayer.Invoke();
    }

    void ResetLayer() => _drawingData.CurrentLayerIndex = 0;
}
