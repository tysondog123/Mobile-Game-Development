using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;

public class ComponentInventory : MonoBehaviour
{
    Button[] Option;
    GameObject currentlySelected;
    [SerializeField]
    GameObject[] Components;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetSelected()
    {
        return currentlySelected;
    }
    public void ChangeSelected(int UID)
    {
        foreach(var component in Components)
        {
            Component type =component.GetComponent<Component>();
            if (type.GetUID() == UID)
            {
                currentlySelected = component;
                return;
            }
        }
        Debug.LogWarning("There is no component with that UID");
        return;
    }
}
