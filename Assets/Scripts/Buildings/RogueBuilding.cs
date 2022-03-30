using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBuilding : Building
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        DisplayButton(ClickManager.bankedClicks >= _buildingCost && !_unlocked);
    }

    protected override void DisplayButton(bool condition)
    {
        base.DisplayButton(condition);
    }
}
