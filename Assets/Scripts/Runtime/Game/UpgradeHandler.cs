using Euphrates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] float _upgradePriceMultiplier;
    [SerializeField] IntSO _upgradeCount;

    [SerializeField] FloatSO _upgradePrice;
    [SerializeField] FloatSO _totalMoney;

    [SerializeField] ParticleSystem _upgradeParticles;
    [SerializeField] List<GameObject> _desks = new List<GameObject>();

    private void Start()
    {
        DeskActivation();
    }
    public void UpgradeDesk()
    {
        //not enough money to upgrade
        if (!(_totalMoney.Value >= _upgradePrice.Value))
        {
            Debug.Log("not enough money");
            return;
        }

        _upgradeCount.Value++;

        if (_upgradeCount.Value >= _desks.Count)
        {
            Debug.Log("Run out of upgrades");
            _upgradeCount.Value = _desks.Count-1;
            return;
        }

        _totalMoney.Value -= _upgradePrice.Value;
        _upgradePrice.Value *= _upgradePriceMultiplier;

        _upgradeParticles.Play();
        DeskActivation();
        Debug.Log("Upgraded");
    }

    private void DeskActivation()
    {
        //goes through all the desks and deactivates them
        //only desk with upgrade value will be activated
        for (int i = 0; i < _desks.Count; i++)
            _desks[i].SetActive(false);

        _desks[_upgradeCount.Value].SetActive(true);
    }
}
