using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float Score;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreUI();
    }
    public void AddScore(int Value)
    {
        Score += Value;
    }
    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {Score}";
    }
    public void updateHpUI(int hp)
    {
        hpText.text = $"HP: {hp}";
    }
}
