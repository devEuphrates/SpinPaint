using System;
using UnityEngine;

public class CustomerMovement : MonoBehaviour, IMovement
{
    Transform _transform;

    bool _moving = false;
    Vector3 _target;

    const float REACH_DISTANCE = .05f;
    float _reachSquared => REACH_DISTANCE * REACH_DISTANCE;

    [SerializeField] float _speed = 10f;

    public event Action OnReached;

    private void Awake() => _transform = transform;

    public void Move(Vector3 position)
    {
        _moving = true;
        _target = position;
    }

    private void Update()
    {
        if (!_moving)
            return;

        Vector3 heading = _target - _transform.position;
        heading.Normalize();

        _transform.forward = heading;

        _transform.position += _speed * Time.deltaTime * heading;

        float distanceSquared = Vector3.SqrMagnitude(_target - _transform.position);

        if (distanceSquared > _reachSquared)
            return;

        _moving = false;
        OnReached?.Invoke();
    }
}
