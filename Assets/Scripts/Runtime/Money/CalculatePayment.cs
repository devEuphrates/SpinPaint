using Euphrates;
using UnityEngine;

public class CalculatePayment : MonoBehaviour
{
    //gets the similiarity percentage and budget for
    [SerializeField] FloatSO _similiarityPercentage;
    [SerializeField] FloatSO _customerBudget;
    [SerializeField] FloatSO _totalMoney;

    [SerializeField] float _bonusMoneyMultiplier;
    float _calculatedPayment;

    public void CalculatePay()
    {
        if(_similiarityPercentage.Value == 100)
            _calculatedPayment = (_customerBudget.Value / 100) * _similiarityPercentage.Value * _bonusMoneyMultiplier;

        else
            _calculatedPayment = (_customerBudget.Value / 100) * _similiarityPercentage.Value;

        _totalMoney.Value += _calculatedPayment;
    }

}
