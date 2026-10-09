using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiltTest : MonoBehaviour
{
    [SerializeField] float deadZone = .05f;
    [SerializeField] float sensetivity = 2f;
    Vector3 neutral;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        if(Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            SetBase();
        }
    }
    public void SetBase()
    {
        if (Accelerometer.current != null)
        {
            neutral = Accelerometer.current.acceleration.ReadValue();
        }
    }
    public float ReadTilt()
    {
        if(Accelerometer.current == null) return 0f;
        float x =Accelerometer.current.acceleration.ReadValue().x-neutral.x;
        if (Mathf.Abs(x) < deadZone) x = 0f;
        return Mathf.Clamp(x * sensetivity, -1f, 1f);
    }
    private void Update()
    {
        if (ReadTilt() > 0) Debug.Log(ReadTilt());
    }
}
