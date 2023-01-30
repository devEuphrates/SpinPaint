using Euphrates;
using UnityEngine;
using UnityEngine.UI;

public class AnimationForButtons : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _reset;
    [SerializeField] TriggerChannelSO _lastLayer;
    [Space]
    [SerializeField] Button _nextButton;
    [SerializeField] Button _finishButton;

    private void OnEnable()
    {
        _reset.AddListener(ResetButons);
        _lastLayer.AddListener(OnLastLayer);
    }
    private void OnDisable()
    {
        _lastLayer.RemoveListener(OnLastLayer);
        _reset.RemoveListener(ResetButons);
    }

    void ResetButons()
    {
        _nextButton.interactable = true;
        _finishButton.interactable = false;

        Vector2 pos = ((RectTransform)_nextButton.transform).anchoredPosition;
        ((RectTransform)_nextButton.transform).anchoredPosition = new Vector2(40, pos.y);
    }

    private void OnLastLayer()
    {
        _nextButton.interactable = false;
        _finishButton.interactable = true;
    }
}
