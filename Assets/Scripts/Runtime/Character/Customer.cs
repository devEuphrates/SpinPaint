using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(IMovement))]
public class Customer : MonoBehaviour
{
    CustomerState _currentState = CustomerState.Idle;
    public event Action<CustomerState> OnStateChanged;

    IMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<IMovement>();
    }

    private void OnEnable()
    {
        _movement.OnReached += MovementFinished;
    }

    private void OnDisable()
    {
        _movement.OnReached -= MovementFinished;
    }

    public void MoveToPosition(Vector3 position)
    {
        _movement.Move(position);
        ChangeState(CustomerState.Moving);
    }

    void MovementFinished() => ChangeState(CustomerState.Idle);

    public void Celebrate() => ChangeState(CustomerState.Happy);

    void ChangeState(CustomerState newState)
    {
        if (_currentState == newState)
            return;

        _currentState = newState;
        OnStateChanged?.Invoke(newState);
    }

    public enum CustomerState
    {
        Idle,
        Moving,
        Happy,
        Sad
    }
}
