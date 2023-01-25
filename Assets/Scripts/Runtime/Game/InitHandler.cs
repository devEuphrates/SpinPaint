using Euphrates;
using UnityEngine;

public class InitHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _loadSaveData;
    [SerializeField] TriggerChannelSO _init;
    [SerializeField] TriggerChannelSO _loadUI;
    [SerializeField] TriggerChannelSO _loadGameScene;

    void Awake() => Application.targetFrameRate = 60;

    private void Start()
    {
        _loadSaveData?.Invoke();
        _init?.Invoke();
        _loadUI?.Invoke();
        _loadGameScene?.Invoke();
    }
}
