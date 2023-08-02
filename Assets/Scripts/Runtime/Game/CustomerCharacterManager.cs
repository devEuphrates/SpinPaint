using Euphrates;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCharacterManager : MonoBehaviour
{
    [SerializeField] List<Customer> _prefabs = new List<Customer>();
    [SerializeField] List<Transform> _positions = new List<Transform>();
    [SerializeReference] Transform _discardedPosition;
    [SerializeReference] IntSO _maxSkips;

    List<Customer> _customers = new List<Customer>();
    int _currentCustomerIndex = 0;

    [Space]
    [Header("Events")]
    [SerializeReference] TriggerChannelSO _nextCustomer;
    [SerializeReference] TriggerChannelSO _orderComplete;
    [SerializeReference] TriggerChannelSO _mainPhase;

    private void OnEnable()
    {
        _mainPhase.AddListener(ResetAll);
        _nextCustomer.AddListener(MoveCustomers);
        _orderComplete.AddListener(OrderComplete);
    }

    private void OnDisable()
    {
        _mainPhase.RemoveListener(ResetAll);
        _nextCustomer.RemoveListener(MoveCustomers);
        _orderComplete.RemoveListener(OrderComplete);
    }

    void Start()
    {
        SpawnCustomers();
    }

    void SpawnCustomers()
    {
        if (_prefabs.Count == 0 || _positions.Count == 0)
            return;

        List<Customer> unselectedPrefabs = new List<Customer>(_prefabs);

        for (int i = 0; i < _positions.Count; i++)
        {
            if (unselectedPrefabs.Count == 0)
                unselectedPrefabs = new List<Customer>(_prefabs);

            Transform selectedNode = _positions[i];

            Customer prefab = unselectedPrefabs.GetRandomItem();
            unselectedPrefabs.Remove(prefab);

            Customer customer = Instantiate(prefab);
            customer.transform.parent = transform;
            customer.transform.SetPositionAndRotation(selectedNode.position, selectedNode.rotation);

            _customers.Add(customer);
        }
    }

    int _skips = 0;
    void MoveCustomers()
    {
        if (++_skips > _maxSkips.Value)
            return;
        
        Customer discardedCustomer = _customers[_currentCustomerIndex++];

        discardedCustomer.MoveToPosition(_discardedPosition.position);

        for (int i = _currentCustomerIndex; i < _customers.Count; i++)
        {
            Vector3 target = _positions[i - _currentCustomerIndex].position;
            _customers[i].MoveToPosition(target);
        }
    }

    void OrderComplete()
    {
        _customers[_currentCustomerIndex].Celebrate();
        _currentCustomerIndex = 0;
    }

    void ResetAll()
    {
        for (int i = _customers.Count - 1; i >= 0; i--)
            Destroy(_customers[i].gameObject);

        _skips = 0;
        _currentCustomerIndex = 0;

        SpawnCustomers();
    }
}
