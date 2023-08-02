using Euphrates;
using UnityEngine;

public class CustomerOrderManager : MonoBehaviour
{
    [SerializeReference] TriggerChannelSO _nextCustomer;
    [SerializeReference] TriggerChannelSO _customerPhase;
    [SerializeReference] TriggerChannelSO _randomPainting;

    [Space]
    [SerializeReference] IntSO _maxSkips;
    [SerializeReference] IntSO _leftSkips;

    [Space]
    [SerializeReference] FloatSO _currentPrice;
    [SerializeField] float _minPrice;
    [SerializeField] float _maxPrice;

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
        _leftSkips.Value = _maxSkips.Value;

        GetOrder();
    }

    void NextCustomer()
    {
        if (_skips + 1 > _maxSkips)
            return;

        _skips++;
        _leftSkips.Value--;

        GetOrder();
    }

    void GetOrder()
    {
        _randomPainting?.Invoke();

        float price = Random.Range(_minPrice, _maxPrice);

        _currentPrice.Value = price;
    }
}
