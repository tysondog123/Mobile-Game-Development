using UnityEngine;

public class MiniGame2Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        InputController inputController = FindFirstObjectByType<InputController>();
        inputController.manager2 = this;
        inputController.SetMiniGameState(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
