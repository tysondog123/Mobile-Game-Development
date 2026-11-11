using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputController : MonoBehaviour
{
    enum Currentminigame 
    {
        minigame1,
        minigame2,
        minigame3,
        mainMenu
    }
    Currentminigame minigame = Currentminigame.mainMenu;
    public MiniGame1Manager manager1;
    public MiniGame2Manager manager2;
    public MiniGame3Manager manager3;

    // Definitions of touchs
    [SerializeField]
    float SwipeLength;
    [SerializeField]
    float holdTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (minigame == Currentminigame.minigame1 && manager1!=null)
        {
            foreach (var touch in Touch.activeTouches)
            {
                if (touch.ended && touch.time - touch.startTime > holdTime)
                {
                    //is a hold
                    manager1.actionController.Input(1);
                }
                else if (touch.ended && (touch.screenPosition - touch.startScreenPosition).magnitude > SwipeLength)
                {
                    // drag
                    manager1.actionController.Input(2);

                }
                else if (touch.ended && touch.time - touch.startTime < holdTime)
                {
                    //tap
                    manager1.actionController.Input(0);
                }
            }
        }
        else if (minigame == Currentminigame.minigame2)
        {

        }else if (minigame == Currentminigame.minigame3)
        {
            foreach (var touch in Touch.activeTouches)
            {
                manager3.Tap(touch);
            }
        }
        
    }
       public void SetMiniGameState(int index)
       {
          index--;
          switch (index)
          {
            case 0:
                minigame = Currentminigame.minigame1;
                break;
            case 1:
                minigame = Currentminigame.minigame2;
                break;
            case 2:
                minigame = Currentminigame.minigame3;
                break;

            case 4:
                minigame = Currentminigame.mainMenu;
                break;
          }

       }


}
