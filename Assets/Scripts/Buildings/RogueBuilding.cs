using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBuilding : Building
{
    [SerializeField] private GameObject _predecessor;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        DisplayButton(ClickManager.bankedClicks >= _buildingCost && !_unlocked && _predecessor.GetComponent<Building>().Unlocked());
    }

    protected override void DisplayButton(bool condition)
    {
        base.DisplayButton(condition);
    }
}
