using UnityEditor.UIElements;
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

    // temp --------------------------------
    public GameObject toSpawn;
    //------------------------------------
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
    public int AddItem(int UDI)
    {
        grid[0][0] = Instantiate(toSpawn, new Vector2(0, 0), Quaternion.identity);
        return 0;
    }
    public int MoveOnGrid(Vector2 CurrentIndex,Vector2 GoalIndex)
    {
        GameObject temp = grid[(int)CurrentIndex.y][(int)CurrentIndex.x];
        
        if (grid[(int)GoalIndex.y][(int)GoalIndex.x]==null)
        {
           temp.transform.position = GoalIndex;
           grid[(int)GoalIndex.y][(int)GoalIndex.x] = temp;
           grid[(int)CurrentIndex.y][(int)CurrentIndex.x] = null;
           return 0; 
        }
        else
        {
            
            Debug.Log("blocked");
            return 1;
        }
        
    }
}
