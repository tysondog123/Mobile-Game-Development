using System;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] SpawnPointOptions;
    public bool Vertical;

    public Vector3 FindPointAlongspan()
    {
        float Span;
        if (Vertical == true) 
        {
            Span= Random.Range(SpawnPointOptions[0].transform.position.x, SpawnPointOptions[1].transform.position.x);
            return new Vector3(Span, SpawnPointOptions[0].transform.position.y, SpawnPointOptions[0].transform.position.z);
        }
        else
        {
            Span = Random.Range(SpawnPointOptions[0].transform.position.y, SpawnPointOptions[1].transform.position.y);
            return new Vector3(SpawnPointOptions[0].transform.position.x,Span, SpawnPointOptions[0].transform.position.z);
        }
    }
}
