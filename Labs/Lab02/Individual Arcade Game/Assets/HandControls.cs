using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class HandControls : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerControlls>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Angel = player.transform.position - transform.position;
        transform.position = transform.position + (Angel.normalized)*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision.name);
            collision.GetComponent<HpController>().takeDamage(1000);
        }
    }
}
