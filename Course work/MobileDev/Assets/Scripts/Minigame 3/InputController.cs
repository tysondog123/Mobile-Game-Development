using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class InputController : MonoBehaviour
{
    MiniGame3Manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<MiniGame3Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectComponent(int UID)
    {
        manager.gridManager.AddItem(UID);
    }
}
