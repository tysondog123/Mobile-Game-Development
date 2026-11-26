using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MiniGame1Manager : MonoBehaviour
{
    public MG1UI UIController;
    public ActionController actionController;
    [SerializeField]
    int MissedActions;
    bool CorrectOrientation = false;
    [SerializeField]
    GameObject[] UIElements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Input.deviceOrientation != DeviceOrientation.Portrait)
        {
            StartCoroutine(CheckRotation());
        }
        else
        {
            Setup();
        }
        
    }
    void Setup()
    {
        CorrectOrientation = true;
        Screen.orientation = ScreenOrientation.Portrait;
        InputController inputController = FindFirstObjectByType<InputController>();
        inputController.manager1 = this;
        inputController.SetMiniGameState(1);
        UIElements[1].SetActive(true);
        UIElements[0].SetActive(false);
    }
    IEnumerator CheckRotation()
    {
        yield return new WaitForSeconds(1);
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Setup();
        }
        else
        {
            StartCoroutine(CheckRotation());
        }
    }
    public void MissedAction()
    {
        MissedActions--;
        if (MissedActions <= 0)
        {
            Lose();
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

}
