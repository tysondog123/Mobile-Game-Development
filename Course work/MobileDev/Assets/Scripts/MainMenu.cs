using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindFirstObjectByType<InputController>().SetMiniGameState(4);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void OpenMinigame(string scene)
   {
        SceneManager.LoadScene(sceneName: scene);
   }
}
