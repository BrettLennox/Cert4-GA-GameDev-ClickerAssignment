using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBuilding : Building
{
    [SerializeField] private int _buildingDamage;
    [SerializeField] private int _buildingClickReward;
    [SerializeField] private GameObject _allyPrefab;
    [SerializeField] private Transform _allyParent;
    private bool _isRunning;
    private ClickManager _cm;

    public override void PurchaseBuilding()
    {
        base.PurchaseBuilding();
        if (_canPurchase)
        {
            _buildingCount++;
            ClickManager.bankedClicks -= _buildingCost;
            _buildingCost += (_buildingCost / 2);
            Instantiate(_allyPrefab, _allyParent);
        }
    }

    protected override void Update()
    {
        base.Update();
        DisplayButton(ClickManager.bankedClicks >= _buildingCost && !_unlocked);
        if (!_isRunning)
        {
            StartCoroutine(AllyBuildingCoroutine());
        }
    }

    protected override void Start()
    {
        base.Start();
        _cm = GameObject.Find("ClickManager").GetComponent<ClickManager>();
    }

    protected override void DisplayButton(bool condition)
    {
        base.DisplayButton(condition);
    }

    private IEnumerator AllyBuildingCoroutine()
    {
        while (_buildingCount >= 1)
        {
            _isRunning = true;
            _cm.DamageBoss(_buildingDamage * _buildingCount);
            ClickManager.bankedClicks += (_buildingClickReward * _buildingCount);
            yield return new WaitForSeconds(1f);
        }
    }
}
