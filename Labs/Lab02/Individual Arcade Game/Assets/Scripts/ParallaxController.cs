using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Vector3 cameraStartPos;
    Vector3 StartPos;
    Vector3 camMotion;

    [SerializeField]
    float modifier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets the startpos veriable to the players origin position and the Camera
        StartPos= transform.position;
        cameraStartPos = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this finds the amount the camera has moved since the start of the came
        camMotion = transform.parent.position - cameraStartPos;
        //sets the position of the background piece to the status plus modifier multiplied by the cam Motion
        transform.position = StartPos+modifier*camMotion;
    }
}
