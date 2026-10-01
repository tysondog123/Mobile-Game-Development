using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField]
    string[] Text;
    [SerializeField]
    TextMeshProUGUI TextBox;
    int current =0;
    [SerializeField]
    AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextBox.maxVisibleCharacters = 0;
        TextBox.text = Text[0];
        StartCoroutine(Talk());
    }

    
    public void Next()
    {
        StopAllCoroutines();
        if(current< Text.Length-1)
        {
            current++;
            TextBox.maxVisibleCharacters = 0;
            TextBox.text = Text[current];
            StartCoroutine(Talk());
        }else
        {
            SceneManager.LoadScene("Main");
        }
        
    }
    IEnumerator Talk()
    {
        yield return new WaitForSeconds(0.05f);
        if (TextBox.maxVisibleCharacters < Text[current].Length)
        {
            TextBox.maxVisibleCharacters+=1;
            source.Play();
            StartCoroutine(Talk());
        }
    }
}
