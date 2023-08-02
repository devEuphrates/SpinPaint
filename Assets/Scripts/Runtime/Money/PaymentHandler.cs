using Euphrates;
using UnityEngine;

public class PaymentHandler : MonoBehaviour
{
    [SerializeField] TriggerChannelSO _evalutionTrigger;

    //gets the similiarity percentage and budget for
    [SerializeField] FloatSO _similiarityPercentage;
    [SerializeField] FloatSO _customerBudget;
    [SerializeField] FloatSO _totalMoney;
    [SerializeField] FloatSO _calculatedPayment;

    [SerializeField] float _bonusMoneyMultiplier;

    private void OnEnable()
    {
        CalculatePay();
    }

    private void CalculatePay()
    {
        if(_similiarityPercentage.Value == 100)
            _calculatedPayment.Value = (_customerBudget.Value / 100) * _similiarityPercentage.Value * _bonusMoneyMultiplier;

        else
            _calculatedPayment.Value = (_customerBudget.Value / 100) * _similiarityPercentage.Value;
    }

    public void MakePayment()
    {
        _totalMoney.Value += _calculatedPayment.Value;
        _calculatedPayment.Value = 0;
    }

}
