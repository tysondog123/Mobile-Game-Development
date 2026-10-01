using System.Collections;
using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public float Timer;
    [SerializeField]
    TextMeshProUGUI TimerText;
    [SerializeField]
    TextMeshProUGUI HPText;
    [SerializeField]
    Slider ProgressBar;
    [SerializeField]
    GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
     
    // Update is called once per frame
    void Update()
    {
        if (Timer > 300)
        {
            Timer = 300;
        }
        TimerText.text = GetTime();
        ProgressBar.value = Timer;
        Timer -= Time.deltaTime;
        string HP = Player.GetComponent<HPController>().GetHP();
        HPText.text ="HP: " + HP;
        if (Timer <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    string GetTime()
    {
        float Seconds;
        Seconds = Timer / 60;
        float Minutes =math.floor(Seconds);
        Seconds-=Minutes;
        Seconds = Seconds * 60;
        Seconds = math.round(Seconds);
        if (Seconds == 60)
        {
            Minutes++;
            Seconds = 0;
        }
        return (Minutes + ":" + Seconds);
    }

    IEnumerator Charge()
    {
       yield return new WaitForSeconds (1f);
        Timer--;
        StartCoroutine(Charge());
    }

}
