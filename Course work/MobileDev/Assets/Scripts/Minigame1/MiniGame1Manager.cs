using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MiniGame1Manager : MonoBehaviour
{
    public MG1UI UIController;
    public ActionController actionController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; 
        InputController inputController = FindFirstObjectByType<InputController>();
        inputController.manager1 = this;
        inputController.SetMiniGameState(1);
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

}
