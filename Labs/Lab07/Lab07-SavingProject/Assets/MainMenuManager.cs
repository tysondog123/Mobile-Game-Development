using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    int highScore=0;
    [SerializeField]
    TextMeshProUGUI ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText.text =$"highScore: {highScore}";
    }
    public void Play()
    {
        SceneManager.LoadScene(sceneName: "GamePlay");
    }
}
