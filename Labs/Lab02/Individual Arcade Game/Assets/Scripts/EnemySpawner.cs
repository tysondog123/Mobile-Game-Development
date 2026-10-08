using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemys;
    public float BossSpawnTime;
    public GameObject Boss;
    public GameObject[] SpawnArea;
    public float currentSpawend;
    public float maxEnemies;
    public float TimeForMoreEnemys;
    public float[] distanceRange;
    Vector2 SpawnPos;
    public int EnemySpawnTypes =3;
    public GameObject Hand;
    public float GameTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //starts a coroutine to incresse max number of enemies 
        StartCoroutine(SpawnTimer());
        StartCoroutine(Spawn());
        StartCoroutine(SpawnBoss());
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    
    // this function checks if the current number of eneimes less than the max.
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.2f);
        if (currentSpawend < maxEnemies)
        {
            // this random number is used to decied which part of the screen to spawn the enemies on. being either top, bottom, left or right
            int ran = Random.Range(0, SpawnArea.Length);

            if (ran >= 1)
            {
                //this sets the SpawnPos variable to be the side of the screen set before plus a random range across that side of the screen
                SpawnPos = new Vector3(SpawnArea[ran].transform.position.x + Random.Range(distanceRange[0], distanceRange[1]), SpawnArea[ran].transform.position.y, SpawnArea[ran].transform.position.z);
            }
            else if (ran <= 2)
            {
                SpawnPos = new Vector3(SpawnArea[ran].transform.position.x, SpawnArea[ran].transform.position.y + Random.Range(distanceRange[2], distanceRange[3]), SpawnArea[ran].transform.position.z);
            }
            else
            {
                Debug.Log(ran);
                SpawnPos = new Vector3(100, 100, 100);
            }
            //spawns a random enemy based on the spawn pos variable and ups the currentSpawend value
            Instantiate(Enemys[Random.Range(0, EnemySpawnTypes)], SpawnPos, Quaternion.identity);
            
            currentSpawend++;
        }
        StartCoroutine(Spawn());
    }
    IEnumerator SpawnBoss()
    {
        //spawns a boss after period of time
        yield return new WaitForSeconds(BossSpawnTime);

        if (BossSpawnTime > 25)
        {
            BossSpawnTime = BossSpawnTime / 2;
        }

        if (EnemySpawnTypes < Enemys.Length)
        {
            EnemySpawnTypes++;
        }
        Instantiate(Boss, new Vector3(SpawnArea[0].transform.position.x, SpawnArea[0].transform.position.y,0), Quaternion.identity);

        currentSpawend++;
        
        StartCoroutine(SpawnBoss());
    }
    // this coroutine starts a timer that increases the max enemies variable after a time and then restarts itself
    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(TimeForMoreEnemys);
        if (maxEnemies < 500)
        {
            maxEnemies += maxEnemies;
        }
        StartCoroutine(SpawnTimer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(GameTime);
        Instantiate(Hand,SpawnArea[2].transform.position, Quaternion.identity);
    }

}
