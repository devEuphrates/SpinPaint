using Euphrates;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [Header("Texts to Set")]
    [SerializeField] TextMeshProUGUI _levelText;
    [Space]
    [Header("Data to Bind")]
    [SerializeField] IntSO _levelIndex;
    [SerializeField] TriggerChannelSO _newLevelSo;

    private void OnEnable()
    {
        _newLevelSo.AddListener(OnLevelChange);
    }

    private void OnDisable()
    {
        _newLevelSo.RemoveListener(OnLevelChange);
    }

    void OnLevelChange()
    {
        _levelText.text = "Level: " + (_levelIndex.Value + 1).ToString();
    }

    private void Start()
    {
        _levelText.text = "Level: " + (_levelIndex.Value + 1).ToString();
    }
}
