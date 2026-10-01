using Unity.VisualScripting;
using UnityEngine;

public class MovingEnemy : BaseEnemyAI
{
    void Update()
    {
        direction = Player.transform.position - transform.position;
        if (direction.magnitude > Distance)
        {
            MoveTo(direction);
        }
        else
        {
            Shoot.fireProjectile(Projectile, spawnPoint, direction, "Player", ProjectileColour);
            transform.RotateAround(Player.transform.position, Vector3.forward, 20 * Time.deltaTime);

        } 
        
    }
}
