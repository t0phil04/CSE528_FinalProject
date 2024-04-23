using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public InstantiateTower nextInstantiateTower;
    // cost of tower
    public int cost;

    // cost of upgrade for tower
    public int upgradeCost;

    // // sell amount of tower
    // public int GetSellAmount()
    // {
    //     return cost / 2;
    // }

    public int sellCost
    {
        get => cost / 2;
    }
}
