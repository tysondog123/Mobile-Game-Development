using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float LifeTime;
    public Vector3 Direction;
    public float Cost;
    public string Tag;
    public float ShotDelay;
    public Color Color;

    [SerializeField]
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sprite.color = Color;
        float Radians = Mathf.Atan2(Direction.x, Direction.y);
        Radians = Radians * (180 / math.PI);
        quaternion Target = Quaternion.Euler(0, 0, -Radians);
        transform.rotation = Target;

        FindFirstObjectByType<GameController>().Timer += Cost;
        Destroy(gameObject,LifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Direction.normalized ) * Time.deltaTime) * Speed;
   
    }


    public void SetStats(Vector2 InDirection, string Intag, Color color)
    {
        Direction =  InDirection;
        Tag = Intag;
        Color = color;
    }
    public void SetStats(Vector2 InDirection, string Intag)
    {
        Direction = InDirection;
        Tag = Intag;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag(Tag))
        {
            collision.GetComponent<HPController>().DealDamage(Damage);
            Destroy(gameObject);
        }
    }



    
}
