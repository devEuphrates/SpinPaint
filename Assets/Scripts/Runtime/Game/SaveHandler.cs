using Euphrates;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _load;
    [SerializeField] TriggerChannelSO[] _saveEvents;

    [Space]
    [SerializeField] SaveLoadSO _saveChannel;
    [SerializeField] IntSO _levelIndex;

    private void OnEnable()
    {
        _load.AddListener(LoadGame);
        for (int i = 0; i < _saveEvents.Length; i++)
            _saveEvents[i].AddListener(SaveGame);
    }

    private void OnDisable()
    {
        _load.RemoveListener(LoadGame);
        for (int i = 0; i < _saveEvents.Length; i++)
            _saveEvents[i].RemoveListener(SaveGame);
    }

    void SaveGame() => _saveChannel.Save(new SaveData() { Level = _levelIndex.Value, Money = 0});

    void LoadGame()
    {
        SaveData data = _saveChannel.Load();
        _levelIndex.Value = data.Level;
    }
}
