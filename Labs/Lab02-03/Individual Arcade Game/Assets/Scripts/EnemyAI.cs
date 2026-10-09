using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    Rigidbody2D RB;

    public float Speed;
    public float Damage;
    Vector2 Angel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //defines both player and RB veriables to be correct- player = player gameobject- RB = ai rigidbody 2D
        Player = FindFirstObjectByType<PlayerControlls>().gameObject;
        RB = GetComponent<Rigidbody2D>();
        StartCoroutine(PathFind());
    }

    // Update is called once per frame
    void Update()
    {
        //sets the AI's Velocity to the angle veriable multiplyed by the speed veriable
        RB.linearVelocity = Angel * Speed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if the AI is collideing with the player it runs the Players takeDamage function, inputing its damage value
            collision.GetComponent<HpController>().takeDamage(Damage);
        }
    }

    //this destroys the AI if it leaves the players screen
    private void OnBecameInvisible()
    {
        FindFirstObjectByType<EnemySpawner>().currentSpawend--;
        Destroy(gameObject);
    }
    IEnumerator PathFind()
    {
        Angel = (Player.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(.5f);
        StartCoroutine(PathFind());
    }
}
