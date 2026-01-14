using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public int width;
    public int height;
    public int tileSize;
    public Vector3 origin;

    private Tile[,] grid;

    private void Awake()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                Vector3 worldPos = GridToWorld(gridPos);
                grid[x, y] = new Tile(gridPos, worldPos);
            }
        }
    }
    public Tile GetTile(int x, int y)
    {
        if(x < 0 || y < 0 || x >= width || y >= height)
        {
            Debug.LogWarning("java.lang.TilesOutOfBoundsException");
            return null;
        }
        return grid[x, y];
    }
    public Vector3 GridToWorld(Vector2Int gridPos)
    {
        return origin + new Vector3(gridPos.x*tileSize,0f,gridPos.y*tileSize);
    }
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / tileSize);
        int y = Mathf.FloorToInt(worldPos.z / tileSize);
        return new Vector2Int(x, y);
    }
    /**
    private void OnDrawGizmos()
    {
        if (width <= 0 || height <= 0) return;

        Gizmos.color = Color.red;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPos = origin + new Vector3(x * tileSize, -y*tileSize,0f);
                Gizmos.DrawWireCube(worldPos + Vector3.up * 0.01f, Vector3.one * (tileSize));
            }
        }
    }
    **/
}
