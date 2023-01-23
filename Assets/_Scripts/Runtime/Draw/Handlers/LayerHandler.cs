using Euphrates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerHandler : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] TriggerChannelSO _layerChange;
    [Space]
    [SerializeField] DrawDataSO _drawingData;

    private void OnEnable()
    {
        _layerChange.AddListener(ChangeLayer);
    }

    private void OnDisable()
    {
        _layerChange.RemoveListener(ChangeLayer);
    }

    private void Start()
    {
        _drawingData.CurrentLayerIndex = 0;
    }

    void ChangeLayer()
    {
        if (_drawingData.CurrentLayerIndex > _drawingData.LayerCount - 1)
        {
            // Painting finished events;
            print("Painting done!");
            return;
        }

        _drawingData.CurrentLayerIndex++;
    }
}
