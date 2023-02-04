using Euphrates;
using UnityEngine;

public class TinySauceInit : MonoBehaviour
{
    [SerializeField] TriggerChannelSO _levelFinished;
    [SerializeField] FloatSO _match;
    [SerializeField] IntSO _level;

    private void OnEnable()
    {
        _levelFinished.AddListener(LevelDone);
    }

    private void OnDisable()
    {
        _levelFinished.RemoveListener(LevelDone);
    }

    void Start()
    {
        TinySauce.OnGameStarted();
    }

    void LevelDone()
    {
        TinySauce.OnGameFinished(true, _match.Value, _level.Value.ToString());
    }
}
