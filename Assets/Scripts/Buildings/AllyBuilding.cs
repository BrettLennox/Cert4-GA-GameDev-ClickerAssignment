using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBuilding : Building
{
    [SerializeField] private float _buildingDamage;
    [SerializeField] private int _buildingClickReward;
    [SerializeField] private GameObject _allyPrefab;
    [SerializeField] private Transform _allyParent;
    private bool _isRunning;
    private BossManager _bossManager;

    protected override void Start()
    {
        base.Start();
        _bossManager = GameObject.Find("GameManager").GetComponent<BossManager>();
    }

    protected override void Update()
    {
        base.Update();
        DisplayButton(ClickManager.bankedClicks >= _buildingCost);
        if (_buildingCount > 0)
        {
            BuildingBehaviour();
        }
    }

    public override void PurchaseBuilding()
    {
        base.PurchaseBuilding();
        //if the condition for canPurchase are true (if we have enough currency to purchase)
        if (_canPurchase)
        {
            //increase the count of buildings owned
            _buildingCount++;
            //decrease value of banked clicks by the cost
            ClickManager.bankedClicks -= _buildingCost;
            //increase the value of the cost for the building
            _buildingCost += (_buildingCost / 4);
            //instantiate the allyPrefab under the allyParent gameobject
            Instantiate(_allyPrefab, _allyParent);
        }
    }

    protected override void DisplayButton(bool condition)
    {
        base.DisplayButton(condition);
    }

    private void BuildingBehaviour()
    {
        //using Mathf.Lerp increase the bankedClicks variable by the buildingReward multiplied by the amount of buildings owned over a set time
        ClickManager.bankedClicks = Mathf.Lerp(ClickManager.bankedClicks, ClickManager.bankedClicks += _buildingClickReward * _buildingCount, 1f * Time.deltaTime);
        _bossManager.BuildingDamageBoss(_buildingDamage * _buildingCount);
    }
}
