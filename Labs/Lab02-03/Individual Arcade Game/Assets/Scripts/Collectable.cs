using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float EXP;

    //gives player EXP on collison, plays collection audio and Destroys gameobejcts after audio finished playing
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindFirstObjectByType<GameController>().GainEXP(EXP);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
