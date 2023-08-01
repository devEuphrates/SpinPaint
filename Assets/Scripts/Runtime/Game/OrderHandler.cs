using Euphrates;
using UnityEngine;

public class OrderHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeReference] TriggerChannelSO _init;
    [SerializeReference] TriggerChannelSO _nextPainting;
    [SerializeReference] TriggerChannelSO _setRandomPainting; 

    [Space]
    [SerializeField] DrawDataSO _drawingData;
    [SerializeField] PaintHolderSO _paintings;
    [SerializeField] IntSO _paintingIndex;

    private void OnEnable()
    {
        _init?.AddListener(SetPainting);
        _nextPainting?.AddListener(NextPainting);
    }

    private void OnDisable()
    {
        _init?.RemoveListener(SetPainting);
        _nextPainting?.RemoveListener(NextPainting);
    }

    void SetPainting() => _drawingData.Painting = _paintings.GetPainting(_paintingIndex, false);

    void NextPainting()
    {
        _paintingIndex.Value++;
        SetPainting();
    }

    public void SetRandomPainting(params int[] avoidedIndexes)
    {

    }
}
