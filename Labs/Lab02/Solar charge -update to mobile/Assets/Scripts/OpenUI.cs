using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ToggelMenu(InputAction.CallbackContext context)
    {
        if (UI.activeSelf)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
        
    }
}
