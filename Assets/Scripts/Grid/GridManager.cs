using UnityEngine;

[ExecuteAlways]
public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public int width;
    public int height;
    public int tileSize;
    public Vector2 origin;

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
                Vector2 worldPos = GridToWorld(gridPos);

                float r = Random.value; // 0.0 – 1.0
                TileType type;

                if (r < 0.1f)
                    type = TileType.Empty;        // 10%
                else if (r < 0.2f)
                    type = TileType.Blocked;      // 10%
                else
                    type = TileType.Ground;       // 80%

                grid[x, y] = new Tile(gridPos, worldPos, type);
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
    public Vector2 GridToWorld(Vector2Int gridPos)
    {
        return origin + new Vector2(
            gridPos.x * tileSize + tileSize * 0.5f,
            gridPos.y * tileSize + tileSize * 0.5f
        );
    }
    public Vector2Int WorldToGrid(Vector2 worldPos)
    {
        int x = Mathf.FloorToInt((worldPos.x - origin.x) / tileSize);
        int y = Mathf.FloorToInt((worldPos.y - origin.y) / tileSize);
        return new Vector2Int(x, y);
    }
    
    private void OnDrawGizmos()
    {
        if (width <= 0 || height <= 0) return;

        if (grid == null)
            CreateGrid();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile tile = grid[x, y];
                if (tile == null) continue;

                switch (tile.TileType)
                {
                    case TileType.Ground: Gizmos.color = Color.green; break;
                    case TileType.Empty: Gizmos.color = Color.yellow; break;
                    case TileType.Blocked: Gizmos.color = Color.red; break;
                }

                Gizmos.DrawWireCube(
                    tile.WorldPosition,
                    new Vector2(tileSize-0.1f, tileSize-0.1f)
                );
            }
        }
    }
    
}
