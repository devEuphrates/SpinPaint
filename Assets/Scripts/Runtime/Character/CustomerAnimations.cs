using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CustomerAnimations : MonoBehaviour
{
    [SerializeReference] Customer _customer;
    Animator _animator;

    [Header("Triggers")]
    [SerializeField] string _idle;
    [SerializeField] string _walk;
    [SerializeField] string _finished;

    private void Awake() => _animator = GetComponent<Animator>();

    private void OnEnable()
    {
        _customer.OnStateChanged += CustomerStateChanged;
    }

    private void OnDisable()
    {
        _customer.OnStateChanged -= CustomerStateChanged;
    }

    void CustomerStateChanged(Customer.CustomerState state)
    {
        switch (state)
        {
            default:
            case Customer.CustomerState.Idle:
                _animator.SetTrigger(_idle);
                break;

            case Customer.CustomerState.Moving:
                _animator.SetTrigger(_walk);
                break;

            case Customer.CustomerState.Happy:
            case Customer.CustomerState.Sad:
                _animator.SetTrigger(_finished);
                break;
        }
    }
}
