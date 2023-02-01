using Euphrates;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventListener : MonoBehaviour
{
    [SerializeField] List<TriggerEventData> _eventActions = new List<TriggerEventData>();

    private void OnEnable()
    {
        foreach (var ea in _eventActions)
            ea.Event.AddListener(ea.OnTrigger.Invoke);
    }

    private void OnDisable()
    {
        foreach (var ea in _eventActions)
            ea.Event.RemoveListener(ea.OnTrigger.Invoke);
    }
}

[System.Serializable]
struct TriggerEventData
{
    public string Name;
    public TriggerChannelSO Event;
    public UnityEvent OnTrigger;
}
