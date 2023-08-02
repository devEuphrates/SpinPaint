using Euphrates;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeReference] TriggerChannelSO _nextCustomer;
    [SerializeReference] TriggerChannelSO _customerPhase;
    [SerializeReference] TriggerChannelSO _randomPainting;
    [SerializeReference] IntSO _maxSkips;

    [Space]
    [SerializeReference] IntSO _currentPrize;
    [SerializeField] int _minPrize;
    [SerializeField] int _maxPrize;
    [SerializeField, Min(1)] int _prizeMultiplier = 1;

    int _skips = 0;

    private void OnEnable()
    {
        _customerPhase.AddListener(EnteredPhase);
        _nextCustomer.AddListener(NextCustomer);
    }

    private void OnDisable()
    {
        _customerPhase.RemoveListener(EnteredPhase);
        _nextCustomer.RemoveListener(NextCustomer);
    }

    void EnteredPhase()
    {
        _skips = 0;

        GetOrder();
    }

    void NextCustomer()
    {
        if (++_skips > _maxSkips)
            return;

        GetOrder();
    }

    void GetOrder()
    {
        _randomPainting?.Invoke();

        int prize = Random.Range(_minPrize, _maxPrize);
        prize *= _prizeMultiplier;

        _currentPrize.Value = prize;
    }
}
