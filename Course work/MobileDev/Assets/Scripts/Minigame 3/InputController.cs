using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputController : MonoBehaviour
{
    MiniGame3Manager manager;
    InputActionAsset Tap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<MiniGame3Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var touch in Touch.activeTouches)
        {
            Vector2 input = Camera.main.ScreenToWorldPoint(touch.screenPosition);
            Vector2 pos = new Vector2(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y));
            Debug.Log(pos);
            if (touch.phase == TouchPhase.Began && pos.x<=manager.gridManager.GetGridSize().x-1&& pos.x >= 0&& pos.y <= manager.gridManager.GetGridSize().y-1 && pos.y >= 0)
            {
                Debug.Log("Tap");
                manager.gridManager.AddItem(pos);
            }
        
        }
        
    }
    public void SelectComponent(int UID)
    {
        manager.ComponentInventory.ChangeSelected(UID);
    }
}
