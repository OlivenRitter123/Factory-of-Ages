using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollection
{
    private List<Building> buildingList;
    public BuildingCollection(List<Building> buildings = null)
    {
        buildingList = buildings ?? new List<Building>();
    }
    public void AddBuilding(Building building)
    {
        buildingList.Add(building);
    }
}
