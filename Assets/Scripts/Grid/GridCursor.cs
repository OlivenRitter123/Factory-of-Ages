using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class GridCursor : MonoBehaviour
{
    public GridManager gm;
    public Transform cursorHover;
    public Transform cursorClick;
    private Camera cam;
    private int countNumber = 0; // only for test

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2Int gridPos = gm.WorldToGrid(mouseWorld);
        Tile tile = gm.GetTile(gridPos.x, gridPos.y);
        HoverTile(tile);
        ClickTile(tile);
    }
    private void HoverTile(Tile tile)
    {
        
        if (tile == null || tile.TileType == TileType.Blocked || tile.TileType == TileType.Empty)
        {
            cursorHover.gameObject.SetActive(false);
            return;
        }
        if (tile.isSelected)
        {
            cursorHover.gameObject.SetActive(false);
            return;
        }
        cursorHover.gameObject.SetActive(true);
        cursorHover.position = tile.WorldPosition;
    }
    private void ClickTile(Tile tile)
    {
        if (Input.GetMouseButtonDown(0) && tile != null)
        {
            if (tile.TileType == TileType.Blocked || tile.TileType == TileType.Empty)
            {
                return; // nichts tun
            }

            tile.isSelected = !tile.isSelected; // toggled pro Tile

            // CursorClick nur anzeigen, wenn Tile jetzt selected ist
            cursorClick.gameObject.SetActive(tile.isSelected);
            cursorClick.position = tile.WorldPosition;
            if (!tile.isOccupied)
            {
                tile.SetBuilding(new Building(BuildingType.ConveyorBelt, new Vector2Int(1, 1), null, "Test" + countNumber)); // null is a temporaty solution for a problem i dont want to fix
                countNumber++;
            }
            Debug.Log(tile.building.name);
            

        }
    }
}
