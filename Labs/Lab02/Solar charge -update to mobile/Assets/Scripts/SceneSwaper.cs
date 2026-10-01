using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwaper : MonoBehaviour
{
    public void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
