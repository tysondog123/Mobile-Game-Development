using UnityEngine;

[RequireComponent (typeof(RectTransform))]

public class SafeAreaFitter : MonoBehaviour
{
    RectTransform panel;
    Rect previousSafe;
    Vector2Int previousSize;
    bool applied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()=> panel = GetComponent<RectTransform>();
    private void OnEnable()=>applied = false;

    
    // Update is called once per frame
    void Update()
    {
        var size = new Vector2Int(Screen.width, Screen.height);
        if (size.x <= 0 || size.y <= 0) return;
        Rect safe = Screen.safeArea;
        if (applied && safe == previousSafe && size == previousSize) return;

        // my code
        Debug.Log($"{Screen.safeArea}  {size}");
        Vector2 anchorMax= new Vector2(Screen.safeArea.max.x/size.x,Screen.safeArea.max.y/size.y).normalized;
        Vector2 anchorMin = new Vector2(Screen.safeArea.min.x/size.x, Screen.safeArea.min.y/size.y).normalized;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
        panel.offsetMax = Vector2.zero;
        panel.offsetMin = Vector2.zero;
        //

        previousSafe = safe;
        previousSize = size;
        applied = true;
    }
}
