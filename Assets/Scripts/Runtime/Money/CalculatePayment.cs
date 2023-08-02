using Euphrates;
using UnityEngine;

public class CalculatePayment : MonoBehaviour
{
    //Checks if we are in evaluation stage
    [SerializeField] TriggerChannelSO _orderCompletedTrigger;

    //gets the similiarity percentage and budget for
    [SerializeField] FloatSO _similiarityPercentage;
    [SerializeField] FloatSO _customerBudget;
    

    [SerializeField] FloatSO _bonusMoneyMultiplier;
    [SerializeField] FloatSO _calculatedPayment;

    private void OnEnable()
    {
        _orderCompletedTrigger.AddListener(CalculatePay);
    }
    private void OnDisable()
    {
        _orderCompletedTrigger.RemoveListener(CalculatePay);
    }
    private void CalculatePay()
    {
        if(_similiarityPercentage.Value == 100)
            _calculatedPayment.Value = (_customerBudget.Value / 100) * _similiarityPercentage.Value * _bonusMoneyMultiplier;

        else
            _calculatedPayment.Value = (_customerBudget.Value / 100) * _similiarityPercentage.Value;
    }

}
