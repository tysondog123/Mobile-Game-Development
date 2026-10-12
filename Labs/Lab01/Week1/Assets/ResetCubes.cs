using UnityEngine;

public class ResetCubes : MonoBehaviour
{
    public GameObject[] cubes;
    public Vector2[] pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos= new Vector2[cubes.Length];
        for(int i =0; i<cubes.Length;i++)
        {
            pos[i]= cubes[i].transform.position;
        }
    }

    public void posReset()
    {
        Debug.Log(pos[0]);
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position=pos[i];
            cubes[i].GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0,0);
        }
    }
}
