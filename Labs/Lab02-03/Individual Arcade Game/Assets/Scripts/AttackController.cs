using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Asthetic")]
    public Sprite Sprite;
    public string Name;
    [TextArea (3,5)]
    public string Description;
    [Header("utility")]
    public Vector3 Size;
    public float Speed;
    public Vector3 DirectionOfMovement;
    public float Damage;
    public int PassThrough;
    public bool IsAOE;
    public float Delay;
    public Vector3[] Angle;
    public int attackAmount;

    public float LifeTime;

    Rigidbody2D RB;
    PlayerStats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();    
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        GetComponent<SpriteRenderer>().sprite=Sprite;
        //sets the local scale of the gameobject to the size veriable multiplyed by the size modifier
        gameObject.transform.localScale=Size*player.AttackSize[player.SizeLVL];
        //sets the damage veriable to the attackDamage veriable multiplyed by the Damage modifier
        Damage = Damage * player.AttackDamage[player.DamageLVL];
        RB = GetComponent<Rigidbody2D>();
        // checks if attack type is AOE and starts the Lifetime Function if it is
        if (IsAOE == true)
        {
            StartCoroutine(Lifetime());
        }
        //sets the velocity to the Direction of movement veriable
        RB.linearVelocity = DirectionOfMovement;
    }

    // Update is called once per frame
    void Update()
    {
        //checks the direction of movement and flips the sprite to face the correct direction
        if (RB.linearVelocityX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //checks if its a AOE on collison and runs approptiate function based on result
        if (IsAOE == true)
        {
            AOE(collision);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAOE == false)
        {
          Projectile(collision);
        }
    }
    //checks collisons Tag and deals dammage if its a enemy
    public void AOE(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HpController>().takeDamage(Damage);
        }
    }
    //deals dammage if its a enemy. also reduces passthrough veriable. destroying the gameobject when it reaches 0
    public void Projectile(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HpController>().takeDamage(Damage);
            if (PassThrough <= 0)
            {
                Destroy(gameObject);
            }
            PassThrough -= 1;
        }
    }
    //destroys the gameobject when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //destroys the gameobject after a specific time
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}
