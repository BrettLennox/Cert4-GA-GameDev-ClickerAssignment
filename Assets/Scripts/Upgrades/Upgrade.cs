using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] protected int upgradeCost;
    [SerializeField] private Text _costText;

    public abstract void PurchaseUpgrade();

    protected virtual void UpdateCostText(int cost)
    {
        //sets the costText to match the cost of the building
        _costText.text = "Cost: " + cost.ToString();
    }
}
