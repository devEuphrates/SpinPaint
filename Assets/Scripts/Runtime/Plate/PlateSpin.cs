using Euphrates;
using UnityEngine;

public class PlateSpin : MonoBehaviour
{
    Transform _transform;

    float _speed;
    [SerializeField] float _idleSpeed = 20f;
    [SerializeField] float _fastSpeed = 200f;
    [SerializeField] TriggerChannelSO _speedUp;
    [SerializeField] TriggerChannelSO _switchToIdle;

    private void Awake()
    {
        _transform = transform;
        _speed = _idleSpeed;
    }

    private void OnEnable()
    {
        _speedUp?.AddListener(Fast);
        _switchToIdle?.AddListener(Idle);
    }

    private void OnDisable()
    {
        _speedUp?.RemoveListener(Fast);
        _switchToIdle?.RemoveListener(Idle);
    }

    void Idle() => _speed = _idleSpeed;

    void Fast() => _speed = _fastSpeed;

    private void FixedUpdate() => _transform.rotation *= Quaternion.Euler(0f, _speed * Time.fixedDeltaTime, 0f);
}
