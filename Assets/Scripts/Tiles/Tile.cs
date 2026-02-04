using UnityEngine;

public class Tile
{
    public Vector2Int GridPosition { get; private set; }
    public Vector3 WorldPosition { get; private set;}
    public TileType TileType { get; set; }
    public bool isOccupied = false;
    public Building building;
    public bool isSelected = false;

    public Tile(Vector2Int gridPos, Vector3 worldPos, TileType tileType)
    {
        GridPosition = gridPos;
        WorldPosition = worldPos;
        TileType = tileType;
    }
    public bool isWalkable()
    {
        switch (TileType)
        {
            case TileType.Ground: return true;
            case TileType.Blocked: return false;
            case TileType.Empty: return false;
            default: return false;
        }
    }
    public bool isBlocked()
    {
        switch (TileType)
        {
            case TileType.Empty: return true;
            case TileType.Ground: return false;
            case TileType.Blocked: return true;
            default: return false;
        }
    }
    public void SetBuilding(Building building)
    {
        this.building = building;
        this.isOccupied = true;
        this.TileType = TileType.Blocked;
    }
    public Building GetBuilding()
    {
        return this.building;
    }
}   
