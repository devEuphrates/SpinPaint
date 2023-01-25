using Euphrates;
using UnityEngine;
using UnityEngine.UI;

public class AnimationForButtons : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _lastLayerTrigger;
    [Space]
    [SerializeField] Button _nextButton;
    [SerializeField] Button _finishButton;

    private void OnEnable()
    {
        _lastLayerTrigger.AddListener(OnLastLayer);
    }
    private void OnDisable()
    {
        _lastLayerTrigger.RemoveListener(OnLastLayer);
    }
    private void OnLastLayer()
    {
        _nextButton.interactable = false;
        _finishButton.interactable = true;
    }
}
