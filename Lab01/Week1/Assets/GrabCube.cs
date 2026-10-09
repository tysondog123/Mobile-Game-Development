using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using System.Collections.Generic;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class GrabCube : MonoBehaviour
{




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()=> EnhancedTouchSupport.Enable();
    private void OnDisable() => EnhancedTouchSupport.Disable();
    // Update is called once per frame
    void Update()
    {
        foreach(var touch in Touch.activeTouches)
        {
            if (touch.phase != TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log($"Finger{touch.finger.index} Down");
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    Debug.Log($"Finger{touch.finger.index} Not moving");
                }
                if(touch.phase == TouchPhase.Moved)
                {
                    Debug.Log($"Finger{touch.finger.index} moving");
                    
                }
            }
            else
            {
                string directionOfSwipe ="Error";                                           
                Vector2 Swipe = (touch.startScreenPosition - touch.screenPosition);
                float dpi =Screen.dpi >0 ?Screen.dpi : 160f;
                float distDP = Swipe.magnitude / (dpi / 160f);
                float time =(float) (touch.time - touch.startTime);

                if(distDP<50 || time > .04f)
                {
                    if(Mathf.Abs(Swipe.x) > Mathf.Abs(Swipe.y))
                    {
                        directionOfSwipe=(Swipe.x > 0 ? "Left" : "Right");
                    }
                    else
                    {
                        directionOfSwipe = (Swipe.y > 0 ? "Down" : "Up");
                    }
                }
                Debug.Log($"swipe in {directionOfSwipe}, {Swipe}"); 
            }
            
        }
        
        
    }



}
