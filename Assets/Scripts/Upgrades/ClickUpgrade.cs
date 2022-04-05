using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUpgrade : Upgrade
{
    private ClickManager _clickManager;

    private void Start()
    {
        _clickManager = GameObject.Find("GameManager").GetComponent<ClickManager>();
    }

    private void Update()
    {
        base.UpdateCostText(upgradeCost);
    }

    public override void PurchaseUpgrade()
    {
        //if we have more banked clicks then the cost of the upgrade
        if (ClickManager.bankedClicks >= upgradeCost)
        {
            //remove the cost of the upgrade from the banked clicks variable
            ClickManager.bankedClicks -= upgradeCost;
            //increase click damage and reward
            _clickManager.clickDamageMultiplier *= 2;
            _clickManager.clickValue *= 2;
            //increase the cost of the upgrade
            int newCost = (upgradeCost * 2) + upgradeCost / 2;
            upgradeCost = newCost;
        }
    }
}
