using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{
    [SerializeField]
    GameObject Pointer;
    [SerializeField]
    GameObject SpawnPoint;
    Vector2 direction;
    [SerializeField]
    FireProjectile Shoot;

    public GameObject Projectile;
    bool FireDelay;
    InputAction Attack;
    PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        Attack = input.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        // gets the cursours position reletive to the screen
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 0;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);

        //creates a angle based on the cursors position reletive to the mothership
        Vector2 VAngle = MousePos - Pointer.transform.position;
        direction = VAngle;
        float Radians = Mathf.Atan2(VAngle.x,VAngle.y);
        Radians = Radians * (180 / math.PI);

        //set's the pointers rotation so it points to the cursor
        quaternion Target = Quaternion.Euler(0, 0, -Radians);
        Pointer.transform.rotation = Target;

    }
    public void onclick()
    {
        StartCoroutine(HoldButton());
    }
    IEnumerator HoldButton()
    {
        Debug.Log(Attack.ReadValue<float>());
        Shoot.fireProjectile(Projectile, SpawnPoint, direction, "Enemy");
        yield return new WaitForSeconds(0.01f);
        if (Attack.ReadValue<float>()==1)
        {
            StartCoroutine(HoldButton());
        }
    }
    
}
