using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [System.Serializable]
    public struct UpgradeData
    {
        [SerializeField] public string upgradeName;
        [SerializeField] public int upgradeCost;
        [SerializeField] public int amountOwned;
    }

    protected abstract void PurchaseUpgrade();
}
