using Euphrates;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    Animator _tutorialAnimator;
    [SerializeField] IntSO _levelIndex;
    [SerializeField] TriggerChannelSO _drawingPhase;
    [SerializeField] TriggerChannelSO _disable;

    private void Awake()
    {
        if (_levelIndex.Value != 0)
            Destroy(this.gameObject);
    }

    void Start() => _tutorialAnimator = GetComponent<Animator>();

    private void OnEnable()
    {
        _drawingPhase.AddListener(TutorialProceed);
        _disable.AddListener(Disable);
    }

    private void OnDisable()
    {
        _drawingPhase.RemoveListener(TutorialProceed);
        _disable.RemoveListener(Disable);
    }

    void Disable() => Destroy(this.gameObject);

    public void TutorialProceed() => _tutorialAnimator.SetInteger("count", _tutorialAnimator.GetInteger("count") + 1);

}
