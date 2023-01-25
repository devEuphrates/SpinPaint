using Euphrates;
using UnityEngine;

public class StencilDisplayer : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _enableEvent;
    [SerializeField] TriggerChannelSO _disableEvent;
    [SerializeField] TriggerChannelSO _layerDone;
    [SerializeField] TriggerChannelSO _changeLayer;
    [Space]
    [SerializeField] Material _stencilMaterial;
    [SerializeField] float _fadeDuration = .5f;
    [SerializeField] DrawDataSO _drawingData;

    private void OnEnable()
    {
        _enableEvent.AddListener(EnableStencil);
        _disableEvent.AddListener(DisableStencil);
        _layerDone.AddListener(OnLayerDone);
    }

    private void OnDisable()
    {
        _enableEvent.RemoveListener(EnableStencil);
        _disableEvent.RemoveListener(DisableStencil);
        _layerDone.RemoveListener(OnLayerDone);
        _stencilMaterial.SetFloat("_Alpha", 0);
    }

    void EnableStencil()
    {
        _stencilMaterial.SetTexture("_AlphaMask", _drawingData.CurrentLayer.Texture);
        Tween.DoTween(0f, 1f, _fadeDuration, Ease.OutQuad, v => _stencilMaterial.SetFloat("_Alpha", v));
    }

    void DisableStencil() => Tween.DoTween(1f, 0f, _fadeDuration, Ease.OutQuad, v => _stencilMaterial.SetFloat("_Alpha", v));

    void OnLayerDone() => Tween.DoTween(1f, 0f, _fadeDuration, Ease.OutQuad, v => _stencilMaterial.SetFloat("_Alpha", v), OnAnimationEnd);

    void OnAnimationEnd()
    {
        if (_drawingData.CurrentLayerIndex >= _drawingData.LayerCount - 1)
            return;

        _changeLayer?.Invoke();
        _stencilMaterial.SetTexture("_AlphaMask", _drawingData.CurrentLayer.Texture);
        Tween.DoTween(0f, 1f, _fadeDuration, Ease.OutQuad, v => _stencilMaterial.SetFloat("_Alpha", v));
    }
}
