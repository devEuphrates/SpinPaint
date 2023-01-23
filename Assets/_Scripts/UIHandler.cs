using TMPro;
using UnityEngine.UI;
using Euphrates;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TriggererdCanvas[] _canvases;
    private void OnEnable()
    {
        for (int i = 0; i < _canvases.Length; i++)
        {
            _canvases[i].Trigger.AddListener(ResetOtherCanvases);
            _canvases[i].Trigger.AddListener(_canvases[i].OnTriggered);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _canvases.Length; i++)
        {
            _canvases[i].Trigger.AddListener(ResetOtherCanvases);
            _canvases[i].Trigger.AddListener(_canvases[i].OnTriggered);
        }
    }

    void ResetOtherCanvases()
    {
        for (int i = 0; i < _canvases.Length; i++)
            _canvases[i].canvas.gameObject.SetActive(false);
    }
}


[System.Serializable]
struct TriggererdCanvas
{
    public string Name;
    public Canvas canvas;
    public TriggerChannelSO Trigger;

    public void OnTriggered()
    {
        canvas.gameObject.SetActive(true);
    }
}