using Euphrates;
using UnityEngine;

public class TargetPlateDisplayer : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _enable;
    [SerializeField] TriggerChannelSO _disable;

    [Space]
    [SerializeField] GameObject _target;
    [SerializeField] Material _targetMaterial;
    [SerializeField] DrawDataSO _drawingData;

    private void Awake()
    {
        _target.SetActive(false);
    }

    private void OnEnable()
    {
        _enable.AddListener(Enable);
        _disable.AddListener(Disable);
    }

    private void OnDisable()
    {
        _enable.RemoveListener(Enable);
        _disable.RemoveListener(Disable);
    }

    void Enable()
    {
        _target.SetActive(true);
        _targetMaterial.SetTexture("_BaseMap", _drawingData.Painting.Painting);
    }

    void Disable() => _target.SetActive(false);
}
