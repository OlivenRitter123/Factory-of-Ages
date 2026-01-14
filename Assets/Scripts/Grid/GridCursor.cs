using UnityEngine;

public class GridCursor : MonoBehaviour
{
    public GridManager gm;
    public Transform cursorVisual;

    private void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2Int gridPos = gm.WorldToGrid(mouseWorld);
        Tile tile = gm.GetTile(gridPos.x, gridPos.y);
        HoverTile(tile);
    }
    private void HoverTile(Tile tile)
    {
        
        if (tile == null || tile.TileType == TileType.Blocked || tile.TileType == TileType.Empty)
        {
            cursorVisual.gameObject.SetActive(false);
            return;
        }
        cursorVisual.gameObject.SetActive(true);
        cursorVisual.position = tile.WorldPosition;
    }
}
