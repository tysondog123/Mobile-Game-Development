using System;
using Unity.Mathematics;
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    protected GameObject Player;
    public float Distance; 

    public float speed;
    [SerializeField]
    protected FireProjectile Shoot;
    [SerializeField]
    protected GameObject spawnPoint;
    [SerializeField]
    protected GameObject Projectile;
    [SerializeField]
    protected Color ProjectileColour;

    protected Vector2 direction;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = FindFirstObjectByType<FollowCursor>().gameObject;

        
        direction = Player.transform.position - transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;

        if (direction.magnitude > Distance)
        {
            MoveTo(direction);
        }
        else
        {
            Shoot.fireProjectile(Projectile, spawnPoint, direction, "Player",ProjectileColour);
        }

    }
    public void MoveTo(Vector3 Target)
    {
        transform.position += (Target.normalized * speed) * Time.deltaTime;
        float Radians = Mathf.Atan2(direction.x, direction.y);
        Radians = Radians * (180 / math.PI);
        quaternion Goal = Quaternion.Euler(0, 0, -Radians);
        transform.rotation = Goal;
    }
    
}
