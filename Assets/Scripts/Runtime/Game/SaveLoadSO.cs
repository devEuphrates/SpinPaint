using UnityEngine;

[CreateAssetMenu(fileName = "New Save & Load Channel", menuName = "SO Channels/Save&Load")]
public class SaveLoadSO : ScriptableObject
{
    readonly string SAVE_NAME = "save_proto";
    [SerializeField] SaveData _default;

    public void Save(SaveData data)
    {
        try
        {
            string dataStr = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SAVE_NAME, dataStr);
            PlayerPrefs.Save();
        }
        catch
        {
            
        }
    }

    public SaveData Load()
    {
        try
        {
            if (!PlayerPrefs.HasKey(SAVE_NAME))
                return _default;

            string dataStr = PlayerPrefs.GetString(SAVE_NAME);
            SaveData data = JsonUtility.FromJson<SaveData>(dataStr);
            return data;
        }
        catch
        {
            return _default;
        }
    }
}

[System.Serializable]
public struct SaveData
{
    public int Level;
    public int Money;
}
