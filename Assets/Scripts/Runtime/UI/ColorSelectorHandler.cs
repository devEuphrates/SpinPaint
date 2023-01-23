using Euphrates;
using UnityEngine;

public class ColorSelectorHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _layerCompleted;
    [SerializeField] TriggerChannelSO _nextLayer;

    [Space]
    [SerializeField] DrawDataSO _drawData;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] ColorSelector[] _colorSelectors;

    private void OnEnable()
    {
        _nextLayer.AddListener(SetSelectors);
        _layerCompleted.AddListener(OnLayerCompleted);

        SetSelectors();
    }

    private void OnDisable()
    {
        _nextLayer.RemoveListener(SetSelectors);
        _layerCompleted.RemoveListener(OnLayerCompleted);
    }

    void OnLayerCompleted()
    {
        _canvasGroup.DoAlpha(0f, .5f);
    }

    void SetSelectors()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.DoAlpha(1f, .5f);

        int correct = Random.Range(0, _colorSelectors.Length);

        for (int i = 0; i < _colorSelectors.Length; i++)
        {
            ColorSelector selector = _colorSelectors[i];
            
            if (correct == i)
            {
                selector.SetColor(_drawData.CurrentLayer.Color);
                continue;
            }

            selector.SetColor(Random.ColorHSV(0, 1, .4f, .6f, 0, 1));
        }
    }
}
