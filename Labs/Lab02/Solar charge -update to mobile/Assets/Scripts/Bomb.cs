using UnityEngine;

public class Bomb : BaseProjectile
{
    public float Range;
    public GameObject Explosion;
    
    private void OnDestroy()
    {
        Collider2D[] Enemys = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (Collider2D Col in Enemys)
        {
            if (Col.GetComponent<BaseEnemyAI>())
            {
                AudioSource source = Instantiate(Explosion, transform.position, Quaternion.identity).GetComponent<AudioSource>(); ;
                source.Play();
                Destroy(source.gameObject,source.clip.length);
                Col.GetComponent<HPController>().DealDamage(Damage);
            }
        }
    }
}
