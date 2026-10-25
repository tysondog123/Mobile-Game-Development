using System.Collections;
using UnityEngine;

public class EnemyControlller : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float timeBetweenShots;
    [SerializeField]
    float moveSpeed= 1f;
    [SerializeField]
    float stopDistance =5f;
    bool canShoot =true;
    public Spawner spawner;

    // Update is called once per frame
    void Update()
    {
        player = FindFirstObjectByType<PlayerControlls>().gameObject;
        Vector3 dir = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y,0);
        if (dir.magnitude > stopDistance)
        {
            transform.position += (dir.normalized * moveSpeed) * Time.deltaTime;
        }
        else if(canShoot==true)
        {
            StartCoroutine(shoot());
        }
    }
    IEnumerator shoot()
    {
        canShoot = false;
        Projectile spawned = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    private void OnDestroy()
    {
        spawner.currentSpawned--;
    }
}
