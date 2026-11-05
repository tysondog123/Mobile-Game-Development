using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using TMPro;

public class OrderControl : MonoBehaviour
{
    [SerializeField]
    Image background;
    [SerializeField]
    Color[] Colours;
    Button[] Buttons;

    int[] order;
    int round = 1;

    int Current=0;
    int chosen =0;
    float timeShown = 1;
    bool isPlaying=false;
    bool isPressed=false;
    [SerializeField]
    TextMeshProUGUI Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Score.text = $"score: {round-1}";
    }
    void loadNewColours()
    {
        Score.text = $"score: {round-1}";
        order = new int[round];
        for (int i = 0; i < round; i++)
        {
            order[i] = Random.Range(0, Colours.Length);
        }
        StartCoroutine(ShowColours());
    }
    public void play()
    {
        if (!isPlaying) 
        {
            isPlaying = true;
            loadNewColours();
        }
       
    }
    IEnumerator ShowColours()
    {
        if (Current < round)
        {
            background.color = Colours[order[Current]];
            Current++;
        }   
        yield return new WaitForSeconds(timeShown);
        background.color = Color.black;
        yield return new WaitForSeconds(timeShown);
        if (Current < round)
        {
            StartCoroutine(ShowColours());
        }
        else
        {
            Current = 0;
        }
    }

    public void Choice(int button)
    {
        if (!isPressed)
        {
            isPressed = true;
            StartCoroutine(ButtonDelay());
            if (order[chosen] == button)
            {
                chosen++;
                if (chosen == round)
                {
                    chosen = 0;
                    round++;
                    loadNewColours();
                }
            }
            else
            {
                SceneManager.LoadScene(sceneName: "Lose");
            }
        }
    }
    IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(.5f);
        isPressed = false;
    }
}
