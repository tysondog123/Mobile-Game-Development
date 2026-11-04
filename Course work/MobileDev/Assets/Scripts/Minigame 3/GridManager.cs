using UnityEngine;

public class GridManager : MonoBehaviour
{
    MiniGame3Manager manager;
    GameObject[][] grid;
    GameObject[] obsticals;
    [SerializeField]
    Vector2 gridSize;

    [SerializeField]
    GameObject temp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setup();
    }
    public Vector2 GetGridSize()
    {
        return gridSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int setup()
    {
        grid = new GameObject[(int)gridSize.y][];
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = new GameObject[(int)gridSize.x];
        }

        for (int i =0;i<grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                Instantiate(temp, new Vector2(j, i), Quaternion.identity);
            }
        }
        return 0;
    }
    public int AddItem()
    {
        return 0;
    }
}
