using Euphrates;
using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [Header("Texts to Set")]
    [SerializeField] TextMeshProUGUI _levelText;
    [Space]
    [Header("Data to Bind")]
    [SerializeField] IntSO _levelIndex;

    private void OnEnable()
    {
        _levelIndex.OnChange += OnLevelChange;
    }

    private void OnDisable()
    {
        _levelIndex.OnChange -= OnLevelChange;
    }

    void OnLevelChange(int _)
    {
        _levelText.text = "Level: " + (_levelIndex.Value + 1).ToString();
    }

    private void Start()
    {
        _levelText.text = "Level: " + (_levelIndex.Value + 1).ToString();
    }
}
