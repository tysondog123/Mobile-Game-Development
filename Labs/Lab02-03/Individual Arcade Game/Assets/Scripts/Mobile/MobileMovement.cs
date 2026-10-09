using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class MobileMovement : MonoBehaviour
{
    [SerializeField] PlayerControlls playerControlls;
    private void OnEnable() => EnhancedTouchSupport.Enable();
    private void OnDisable() => EnhancedTouchSupport.Disable();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var touch in Touch.activeTouches)
        {
            if (touch.phase != TouchPhase.Ended)
            {
                Debug.Log("test");
               Vector2 Direction = (touch.screenPosition-touch.startScreenPosition).normalized;
                playerControlls.Move(Direction);
            }
            else
            {
                playerControlls.Move(new Vector2(0f,0f));
            }
        }
    }
}
