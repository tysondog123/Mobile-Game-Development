using System.Collections;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
   
    bool FireDelay =true;
    public void fireProjectile(GameObject Projectile, GameObject SpawnPoint, Vector3 Direction,string Tag)
    {
        
        if (FireDelay)
        {
            Debug.Log("Fire");
            StartCoroutine(Fire(Projectile, SpawnPoint, Direction,Tag));
        }
        
    }
    IEnumerator Fire(GameObject Projectile, GameObject SpawnPoint,Vector3 Direction,string Tag)
    {
        FireDelay = false;
        BaseProjectile Spawned = Instantiate(Projectile, SpawnPoint.transform.position, Quaternion.identity).GetComponent<BaseProjectile>();
        Spawned.SetStats(Direction, Tag);
        yield return new WaitForSeconds(Spawned.ShotDelay);
        FireDelay = true;


    }






    //overide to change projectile colour


    public void fireProjectile(GameObject Projectile, GameObject SpawnPoint, Vector3 Direction, string Tag,Color color)
    {

        if (FireDelay)
        {
            Debug.Log("Fire");
            StartCoroutine(Fire(Projectile, SpawnPoint, Direction, Tag,color));
        }

    }
    IEnumerator Fire(GameObject Projectile, GameObject SpawnPoint, Vector3 Direction, string Tag,Color color)
    {
        FireDelay = false;
        BaseProjectile Spawned = Instantiate(Projectile, SpawnPoint.transform.position, Quaternion.identity).GetComponent<BaseProjectile>();
        Spawned.SetStats(Direction, Tag,color);
        yield return new WaitForSeconds(Spawned.ShotDelay);
        FireDelay = true;


    }
}
