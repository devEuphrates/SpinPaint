using Euphrates;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _load;
    [SerializeField] TriggerChannelSO[] _saveEvents;

    [Space]
    [Header("Save")]
    [SerializeField] SaveLoadSO _saveChannel;
    [SerializeField] FloatSO _totalMoney;
    [SerializeField] IntSO _deskUpgradeCount;
    [SerializeField] FloatSO _deskUpgradePrice;

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

    void SaveGame()
    {
        _saveChannel.Save(new SaveData()
        {
            Money = _totalMoney.Value,
            UpgradeCount = _deskUpgradeCount.Value,
            UpgradeCost = _deskUpgradePrice.Value
        });
    }

    void LoadGame()
    {
        SaveData data = _saveChannel.Load();

        _totalMoney.Value = data.Money;
        _deskUpgradeCount.Value = data.UpgradeCount;
        _deskUpgradePrice.Value = data.UpgradeCost;
    }
}
