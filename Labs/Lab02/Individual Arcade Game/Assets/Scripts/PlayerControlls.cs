using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControlls : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    PlayerStats stats;

    bool canTeleport=true;
    public GameObject PauseMenu;
    Animator animator;

    public TextMeshProUGUI HpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        animator= GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //sets Animator veriable "Speed" to rigidbodys velocity
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);
        //Updates UI HP text to be current HP
        HpText.text = "HP: " + GetComponent<HpController>().HP.ToString() +"/"+ GetComponent<HpController>().MaxHp.ToString();
    }
    // Ataches to the player input veriable and runs whenver a key releted to the move event is pressed or held, it also provides a vector 2 value
    public void Move(InputAction.CallbackContext context)
    {
        //sets the rigidbodys Linear velocity to be equal to the provided vector 2 timed by the speed veria variable
        rb.linearVelocity = context.ReadValue<Vector2>() * (Speed * stats.SpeedBoost[stats.SpeedLVL]);
    }
    public void Teleport(InputAction.CallbackContext context)
    {
        // checks if the player has unlocked the teleport abilitys. if they have and press the correct key, adds specific Value to Transform position
        if (canTeleport) 
        {
           transform.position = new Vector2(transform.position.x, transform.position.y) + (rb.linearVelocity.normalized) * stats.TeleportDistance[stats.TeleportLVL];
            canTeleport = false;
            // starts delay timer
            StartCoroutine(TeleportDelay());
        }
    }
    public void Pause()
    {
        // paues game and enables Pause UI when function is ran.
        FindFirstObjectByType<EventSystem>().SetSelectedGameObject(PauseMenu.transform.Find("Resume").gameObject);
        if (PauseMenu.activeSelf)
        {
            PauseMenu.GetComponent<MenuControl>().Resume();
        }
        else if (!PauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
        
    }
    //waits for specifc time before making CanTeleport true
    IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(stats.TeleportDelay[stats.TeleportLVL]); 
        canTeleport = true;
    }
}
