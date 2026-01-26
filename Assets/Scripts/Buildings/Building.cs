using UnityEngine;

public class Building
{
    public BuildingType Type { get; }
    public Vector2Int Size { get; }
    public TileType[] OccupiedTiles;

    public Building(BuildingType type, Vector2Int  size, TileType[] occupiedTiles)
    {
        this.Type = type;
        this.Size = size;
        this.OccupiedTiles = occupiedTiles;
    }

}
