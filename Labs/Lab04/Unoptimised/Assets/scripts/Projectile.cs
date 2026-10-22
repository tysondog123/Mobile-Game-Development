using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    float stopDistance = 5f;
    Vector3 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerControlls>().gameObject;
        dir = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindFirstObjectByType<PlayerControlls>().gameObject;
        transform.position += (dir * moveSpeed) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
