using Euphrates;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpin : MonoBehaviour
{
    Transform _transform;

    static float _speed;
    [SerializeField] List<PlateSpeedEvents> _plateSpeedEvents = new List<PlateSpeedEvents>();

    private void Awake()
    {
        _transform = transform;
        _speed = 0;
    }

    private void OnEnable()
    {
        foreach (var ev in _plateSpeedEvents)
            ev.Event.AddListener(ev.SetSpeed);
    }

    private void OnDisable()
    {
        foreach (var ev in _plateSpeedEvents)
            ev.Event.RemoveListener(ev.SetSpeed);
    }

    private void FixedUpdate() => _transform.rotation *= Quaternion.Euler(0f, _speed * Time.fixedDeltaTime, 0f);

    [System.Serializable]
    public struct PlateSpeedEvents
    {
        public TriggerChannelSO Event;
        public float Speed;
        public void SetSpeed() => _speed = Speed;
    }
}