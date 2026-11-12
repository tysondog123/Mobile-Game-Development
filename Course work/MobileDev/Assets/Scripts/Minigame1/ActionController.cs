using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ActionController : MonoBehaviour
{
    enum Action
    {
        tap,
        hold,
        swipe,
        pinch,
        strech,
        turn,
        shake
    }
    MiniGame1Manager manager;
    Action currrentAction;
    float waitTime =.5f;
    bool awaitingInput= false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<MiniGame1Manager>();
        PickAction();
    }

    // Update is called once per frame
    void Update()  
    {
        
    }
    void PickAction()
    {
        int pickedAction =Random.Range(0, 3);
        awaitingInput = true;
        switch (pickedAction)
        {
            case 0:
                currrentAction = Action.tap;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 1:
                currrentAction = Action.hold;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 2:
                currrentAction = Action.swipe;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 3:
                currrentAction = Action.pinch;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 4:
                currrentAction = Action.strech;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 5:
                currrentAction = Action.turn;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
            case 6:
                currrentAction = Action.shake;
                manager.UIController.UpdateActionUI(currrentAction.ToString());
                break;
        }
    }
    public void Input(int index)
    {

        Debug.Log("input called");
        if (awaitingInput)
        {
            if (index == (int)currrentAction)
            {
                awaitingInput = false;
                StartCoroutine(DownTime());
                manager.UIController.IsCorrect(true);
            }
            else
            {
                manager.UIController.IsCorrect(false);
            }
        }
    }
    IEnumerator DownTime()
    {
        yield return new WaitForSeconds(waitTime);
        PickAction();
    }
}
