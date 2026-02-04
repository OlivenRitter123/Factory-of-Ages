using UnityEngine;

public class Building
{
    public BuildingType Type { get; }
    public Vector2Int Size { get; }
    public TileType[] OccupiedTiles;
    public string name;

    public Building(BuildingType type, Vector2Int  size, TileType[] occupiedTiles, string name)
    {
        this.Type = type;
        this.Size = size;
        this.OccupiedTiles = occupiedTiles;
        this.name = name;
        
    }

}
