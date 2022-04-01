using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCritUpgrade : Upgrade
{
    [SerializeField] private UpgradeData _upgrade;
    protected override void UpgradeBehaviour()
    {
        if (ClickManager.bankedClicks >= _upgrade.upgradeCost)
        {
            if (!ClickManager.shouldCrit)
            {
                ClickManager.shouldCrit = true;
            }
            ClickManager.bankedClicks -= _upgrade.upgradeCost;
            _upgrade.amountOwned++;
        }
    }
}
