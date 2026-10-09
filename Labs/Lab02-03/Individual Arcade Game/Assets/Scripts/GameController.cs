using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float Score;
    public float EXP;
    public float ExpToNextLevel;
    public float[] LastExpLevelCount;

    public GameObject AbilliteWheel;

    public Slider ExpBar;
    
    //ups player EXP also if the exp is more than ExpToNextLevel activates the ability wheel and resets EXP to Zero
    public void GainEXP(float exp)
    {
        EXP += exp;
        if (EXP >= ExpToNextLevel)
        {
            EXP = 0;
            FindFirstObjectByType<EventSystem>().SetSelectedGameObject(AbilliteWheel.transform.Find("Option 1").gameObject);
            AbilliteWheel.SetActive(true);
            //doubles ExpToNextLevel's Value
            if (ExpToNextLevel < 30)
            {
                LastExpLevelCount[0] = ExpToNextLevel/2;
                ExpToNextLevel += LastExpLevelCount[1];
                LastExpLevelCount[1] = LastExpLevelCount[0];
            }
            
        }
        //Sets the EXP bar values to match new values
        ExpBar.maxValue=ExpToNextLevel;
        ExpBar.value=EXP;
    }
}
