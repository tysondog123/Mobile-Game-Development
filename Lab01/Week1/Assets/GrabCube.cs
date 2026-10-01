using UnityEngine;
using UnityEngine.InputSystem;

public class GrabCube : MonoBehaviour
{
    [SerializeField] InputActionReference Grab;
    [SerializeField] GameObject background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Grab.action.ReadValue<bool>());
        if (Grab.action.ReadValue<bool>())
        {
            background.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
    }
}
