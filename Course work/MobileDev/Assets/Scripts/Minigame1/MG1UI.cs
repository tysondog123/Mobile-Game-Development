using TMPro;
using UnityEngine;
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
    private void Start()
    {
        manager = FindFirstObjectByType<MiniGame1Manager>();
    }
    public void UpdateActionUI(string Action)
    {
        ActionText.text = Action;
    }

    public void IsCorrect(bool match)
    {
        if (match)
        {
            background.color = Color.green;
        }
        else
        {
            background.color = Color.red;
        }
    }
}
