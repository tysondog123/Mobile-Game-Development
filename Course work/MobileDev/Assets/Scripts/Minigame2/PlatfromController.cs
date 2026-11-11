using UnityEngine;
using UnityEngine.InputSystem;
public class PlatfromController : MonoBehaviour
{
    [SerializeField]
    float deadZone;
    Vector3 currentRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        currentRot = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(gameObject.transform.eulerAngles.z);
        float input = Accelerometer.current.acceleration.ReadValue().x;
        if (Mathf.Abs(input) > deadZone)
        { 
            float tilt = Mathf.Clamp(input, -0.45f, 0.45f);
            TiltBeam(input);
        }
    }
    public void TiltBeam(float RotateNum)
    {
        if (Mathf.Abs(currentRot.z+ RotateNum) < 10f)
        {
            currentRot.z += RotateNum;
            gameObject.transform.eulerAngles = currentRot;
        }
    }
}
