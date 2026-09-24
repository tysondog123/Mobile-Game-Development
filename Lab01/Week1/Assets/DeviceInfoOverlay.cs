using System.ComponentModel;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class DeviceInfoOverlay : MonoBehaviour
{
    float smoothedDelta = 1f / 30f;
    GUIStyle style;
    public int infoSize;
    public float InfoSizeX;
    public float InfoSizeY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InfoSizeX = infoSize;
        InfoSizeY= infoSize/2;
        style.fontSize = infoSize;
    }
    void OnGUI()
    {
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.box);
            style.alignment = TextAnchor.UpperLeft;
            style.normal.textColor = Color.white;
            
        }

        // TODO: a fixed font size is unreadable on a high-DPI phone.
        // Set style.fontSize relative to Screen.height instead.

        float fps = 1f / smoothedDelta;

        string info = $"FPS: {fps:0}\nRefresh:{Screen.currentResolution.refreshRateRatio}\nDPI:{Screen.dpi}\nGPU: {SystemInfo.graphicsDeviceName}\nGPU Ram:{SystemInfo.graphicsMemorySize/1024}GB\nRam:{SystemInfo.systemMemorySize/1024}GB";
        // TODO: append device model, operating system, resolution,
        // refresh rate, DPI, GPU name, graphics memory and system memory.

        Vector2 size = style.CalcSize(new GUIContent(info));
        GUI.Label(new Rect(40, 40, size.x + InfoSizeX, size.y + InfoSizeY), info, style);
    }
}
