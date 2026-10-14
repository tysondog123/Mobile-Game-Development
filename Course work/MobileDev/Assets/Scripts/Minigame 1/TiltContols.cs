using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class TiltContols : MonoBehaviour
{
    [SerializeField]
    float sensetivity;
    [SerializeField]
    float deadZone;

    Vector3 baseLine;

    [SerializeField]
    GameObject Beam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (Gyroscope.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            SetBase();
        }
        else
        {

            Debug.Log("No Gyro");
        }
    }
    public void SetBase()
    {
        baseLine =Accelerometer.current.acceleration.ReadValue();
        Debug.Log(baseLine);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Accelrot = Accelerometer.current.acceleration.ReadValue();
        if (Mathf.Abs(Accelrot.x) > baseLine.x + deadZone)
        {
            Debug.Log(Accelrot);
            
            Beam.transform.Rotate(new Vector3(Accelrot.x,Accelrot.y,Accelrot.z*360));
            Quaternion Goal = Quaternion.Euler(0,0,Accelrot.z * 360);
            Beam.transform.rotation= Quaternion.Lerp(Beam.transform.rotation, Goal, .1f);
        }
        
    }
}
