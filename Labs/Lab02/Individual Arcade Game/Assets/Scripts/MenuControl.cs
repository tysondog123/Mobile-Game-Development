using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject LevelUp;
    public AudioSource buttonAudio;
    public float waitTime;
    
    //this finction is used to load the gameplay scene
    public void Play(Button button)
    {
        buttonAudio.Play();
        StartCoroutine(ButtonWait(1));
        button.enabled = false;
    }
    //returns the player to the main menu screen
    public void ReturnToMainMenu(Button button)
    {
        buttonAudio.Play();
        StartCoroutine(ButtonWait(0));
        Time.timeScale = 1.0f;
    }
    //makes the game wait a set time before changing scene
    IEnumerator ButtonWait(int SceneIndex)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneBuildIndex:SceneIndex);
    }
    //quits the game
    public void Quit()
    {
        Application.Quit();
    }

    //unpauses the game
    public void Resume()
    {
        buttonAudio.Play();
        if (!LevelUp.activeSelf)
        {
           Time.timeScale = 1.0f;
        }
        gameObject.SetActive(false);
        
    }
}
