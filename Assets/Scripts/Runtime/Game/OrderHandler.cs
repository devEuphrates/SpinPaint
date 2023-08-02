using Euphrates;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeReference] TriggerChannelSO _init;
    [SerializeReference] TriggerChannelSO _nextPainting;
    [SerializeReference] TriggerChannelSO _setRandomPainting; 

    [Space]
    [SerializeReference] DrawDataSO _drawingData;
    [SerializeReference] PaintHolderSO _paintings;
    [SerializeReference] IntSO _paintingIndex;
    [SerializeReference] IntListSO _avoidedIndexList;

    private void OnEnable()
    {
        //_init?.AddListener(SetRandomPainting);
        //_nextPainting?.AddListener(SetRandomPainting);
        _setRandomPainting?.AddListener(SetRandomPainting);
    }

    private void OnDisable()
    {
        //_init?.RemoveListener(SetRandomPainting);
        //_nextPainting?.RemoveListener(SetRandomPainting);
        _setRandomPainting?.RemoveListener(SetRandomPainting);
    }

    //void SetPainting() => _drawingData.Painting = _paintings.GetPainting(_paintingIndex, false);

    //void NextPainting()
    //{
    //    _paintingIndex.Value++;
    //    SetPainting();
    //}

    public void SetRandomPainting()
    {
        List<int> indexes = Enumerable.Range(0, _paintings.Count).ToList();

        indexes.RemoveAll(index =>
        {
            foreach (var item in _avoidedIndexList)
            {
                if (item == index)
                    return true;
            }

            return false;
        });

        int rnd = Random.Range(0, indexes.Count);
        int randomIndex = indexes[rnd];

        _drawingData.Painting = _paintings.GetPainting(rnd);
        _paintingIndex.Value = randomIndex;
    }
}
