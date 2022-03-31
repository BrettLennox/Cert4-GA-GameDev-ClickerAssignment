using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [Header("Building Data/Compnents")]
    [SerializeField] protected int _buildingCost;
    [SerializeField] protected int _buildingCount;
    [SerializeField] protected bool _canPurchase;
    [SerializeField] protected Text _costText;
    [SerializeField] protected Text _buildingCountText;
    [SerializeField] protected bool _unlocked;
    [SerializeField] protected bool _hasBought;

    protected virtual void Start()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
    }

    public virtual void PurchaseBuilding()
    {
        if(ClickManager.bankedClicks >= _buildingCost)
        {
            _canPurchase = true;
        }
        else
        {
            _canPurchase = false;
        }
    }

    protected virtual void Update()
    {
        UpdateBuildingCostText();
        UpdateBuildingCountText();
    }

    protected virtual void DisplayButton(bool condition)
    {
        if (condition)
        {
            _unlocked = true;
            foreach (Transform item in transform)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    private void UpdateBuildingCostText()
    {
        _costText.text = "Cost: " + _buildingCost.ToString();
    }

    private void UpdateBuildingCountText()
    {
        _buildingCountText.text = _buildingCount.ToString();
    }

    public bool Unlocked()
    {
        return _hasBought;
    }
}
