using UnityEngine;
using UnityEngine.UI;

public class ComponentButton : MonoBehaviour
{
    [SerializeField]
    GameObject componentPrefab;
    Component component;
    Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (componentPrefab != null)
        {
            image = transform.GetChild(0).GetComponent<Image>();
            component = componentPrefab.GetComponent<Component>();
            image.sprite = component.GetSprite();
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
