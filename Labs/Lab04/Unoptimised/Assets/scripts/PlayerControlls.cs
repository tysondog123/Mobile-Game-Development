using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField]
    InputActionReference moveAction;
    [SerializeField]
    float moveSpeed =1;
    [SerializeField]
    float HP;

    GameController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<GameController>();
        controller.updateHpUI((int)HP);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(moveAction.action.ReadValue<Vector2>().x, moveAction.action.ReadValue<Vector2>().y, 0);
        transform.position += (direction*moveSpeed)*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            controller.AddScore(1);
        }
    }

    public void takeDamage(int Damage)
    {
        if (HP - Damage > 0)
        {
            HP -= Damage;
            controller.updateHpUI((int)HP);
        }
        else
        {
            SceneManager.LoadScene(sceneBuildIndex:2);
        }
    }
}
