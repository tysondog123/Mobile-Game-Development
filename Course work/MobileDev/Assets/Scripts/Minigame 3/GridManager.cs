using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    MiniGame3Manager manager;
    GameObject[][] grid;
    GameObject[] obsticals;
    List<GameObject> components = new List<GameObject>();
    [SerializeField]
    Vector2 gridSize;

    [SerializeField]
    GameObject temp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> GetList()
    {
        return components;
    }
    void Start()
    {
        setup();
        manager = FindFirstObjectByType<MiniGame3Manager>();
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
        grid = new GameObject[(int)gridSize.x][];
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = new GameObject[(int)gridSize.y];
        }

        for (int i =0;i<grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                Instantiate(temp, new Vector2(i, j), Quaternion.identity);
            }
        }
        return 0;
    }
    public int AddItem(Vector2 Position)
    {
<<<<<<< Updated upstream
        grid[2][0] = Instantiate(toSpawn, new Vector2(0, 2), Quaternion.identity);
=======
        Vector2 pos = new Vector2((int)Position.x, (int)Position.y);
        GameObject spawned = Instantiate(manager.ComponentInventory.GetSelected(), pos, Quaternion.identity);
        grid[(int)pos.x][(int)pos.y] = spawned;
        components.Add(spawned);
>>>>>>> Stashed changes
        return 0;
    }
    public GameObject GetObjectAtIndex(Vector2 Index)
    {
        if (grid[(int)Index.y][(int)Index.x] == null)
        {
            return null;
        }
        else
        {
            return grid[(int)Index.y][(int)Index.x];
        }
    }
    public int MoveOnGrid(Vector2 CurrentIndex,Vector2 GoalIndex)
    {
<<<<<<< Updated upstream
        GameObject temp = GetObjectAtIndex(CurrentIndex);
        
        if (grid[(int)GoalIndex.y][(int)GoalIndex.x]==null)
=======
        if(grid[(int)CurrentIndex.x][(int)CurrentIndex.y] == null)
        {
            return 1;
        }
        GameObject temp = grid[(int)CurrentIndex.x][(int)CurrentIndex.y];
        Debug.Log($"{CurrentIndex} {GoalIndex}");
        if (grid[(int)GoalIndex.x][(int)GoalIndex.y]==null)
>>>>>>> Stashed changes
        {
           temp.transform.position = GoalIndex;
           grid[(int)GoalIndex.x][(int)GoalIndex.y] = temp;
           grid[(int)CurrentIndex.x][(int)CurrentIndex.y] = null;
           return 0; 
        }
        else
        {
            return 1;
        }
        
    }
}
