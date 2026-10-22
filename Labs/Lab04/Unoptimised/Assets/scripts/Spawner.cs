using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    int spawnAmount;
    public int currentSpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawned < spawnAmount)
        {
            EnemyControlller _enemy = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity).GetComponent<EnemyControlller>();
            _enemy.spawner = gameObject.GetComponent<Spawner>();
            currentSpawned++;
        }
    }
}
