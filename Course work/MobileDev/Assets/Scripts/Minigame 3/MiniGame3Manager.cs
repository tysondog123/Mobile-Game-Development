using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.VisualScripting;

public class MiniGame3Manager : MonoBehaviour
{
    public GridManager gridManager;
    public ComponentInventory ComponentInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        InputController inputController = FindFirstObjectByType<InputController>();
        inputController.manager3 = this;
        inputController.SetMiniGameState(3);
    }

    // Update is called once per frame
    public void SelectComponent(int UID)
    {
        ComponentInventory.ChangeSelected(UID);
    }
    public  void Tap(Touch touch)
    {

        Vector2 input = Camera.main.ScreenToWorldPoint(touch.screenPosition);
        Vector2 pos = new Vector2(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y));
        if (touch.phase == TouchPhase.Began && pos.x <= gridManager.GetGridSize().x - 1 && pos.x >= 0 && pos.y <= gridManager.GetGridSize().y - 1 && pos.y >= 0)
           {
                    Debug.Log("Tap");
                    gridManager.AddItem(pos);
           }
    }
}
