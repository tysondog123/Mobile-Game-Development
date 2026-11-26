using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MG1UI : MonoBehaviour
{
    MiniGame1Manager manager;
    [SerializeField]
    TextMeshProUGUI ActionText; // this is a temp var
    [SerializeField]
    Image background;
    [SerializeField]
    Image image;
    [SerializeField]
    TextMeshProUGUI ScoreText;
    int TempScore;
    private void Start()
    {
        manager = FindFirstObjectByType<MiniGame1Manager>();
    }
    public void UpdateActionUI(string Action)
    {

        ActionText.text = Action;
        TempScore++;
        ScoreText.text = $"Score: {TempScore}";
    }

    public void IsCorrect(bool match)
    {
        if (match)
        {
            background.color = Color.green;
            ProgressStore.Instance.Tracker.OnEnemyDefeated();
            StartCoroutine(Greentime());
        }
        else
        {
            background.color = Color.red;
            ProgressStore.Instance.Tracker.OnLevelCompleted(1,1);
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
    IEnumerator Greentime()
    {
        yield return new WaitForSeconds(1);
        background.color = Color.black;
    }
}
