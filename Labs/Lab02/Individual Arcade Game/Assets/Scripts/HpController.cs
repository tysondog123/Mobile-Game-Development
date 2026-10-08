using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HpController : MonoBehaviour
{
    public float MaxHp;
    public float HP;
    public float IvTime;
    bool Invincible =false;

    public bool player =false;
    public GameObject OnDeath;
    public TextMeshProUGUI scoreText;

    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    public void takeDamage(float Dammage)
    {
        //checks if character has IV frames
        if (IvTime > 0) 
        {
            //checks if character is currrently invincible
            if (!Invincible)
            {
                //if character isnt invincible. runs IVFrames function, sets invincible to true and reduces HP by dammage Amount
                Invincible = true;
                HP -= Dammage;
                StartCoroutine(IVFrames());
                if (player == true)
                {
                    //if character is player. play sound on dammage
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            //if no iv frames just take dammage
            HP -= Dammage;
            
        }
        //if character isnt player and hp=0. add max hp to score, reduce current spawned value and destroy gameobject
        if (HP <= 0 && player ==false)
        {

            GameObject Spawned = Instantiate(OnDeath,transform.position,Quaternion.identity);
            FindFirstObjectByType<EnemySpawner>().currentSpawend--;
            FindFirstObjectByType<GameController>().Score += MaxHp;
            Destroy(gameObject);
        }
        //if character is player and HP =0.
        else if (HP <= 0 && player == true)
        {
            GetComponent<PlayerControlls>().enabled = false;
            //disabple player controlls script
            Time.timeScale = 0f;
            //set UI current selcted to play button on lose screen
            FindFirstObjectByType<EventSystem>().SetSelectedGameObject(OnDeath.transform.Find("Play Button").gameObject);
            //enable Lose screen UI
            OnDeath.SetActive(true);
            // update lose score
            scoreText.text = "Score : " + FindFirstObjectByType<GameController>().Score;
        }

    }
    

   
    IEnumerator IVFrames()
    {
        float FlashAmount =0;
        while (FlashAmount<IvTime) 
        {
            //flashes character sprite when invincible
            if (spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else if(spriteRenderer.enabled == false)
            {
                spriteRenderer.enabled = true;
            }
            FlashAmount += IvTime / 10;
            yield return new WaitForSeconds(IvTime / 10);
        }
        //makes invincible false after timer finished
        spriteRenderer.enabled = true;
        Invincible=false;
    }
}
