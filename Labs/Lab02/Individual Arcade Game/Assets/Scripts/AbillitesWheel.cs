using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbillitesWheel : MonoBehaviour
{
    public TextMeshProUGUI[] OptionText;
    public Image[] optionImage;
    public GameObject[] Abilites;
    public int[] choices;
    PlayerStats playerStats;
    SpawnAttacks spawnAttacks;
    GameObject[] avalibleAbilitys;

    [Header("Description")]
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats=FindFirstObjectByType<PlayerStats>();
        //sets the length of the AbbiliteLVL array to the Number of abilites
        playerStats.AbbiliteLVL=new int[Abilites.Length];
        //adds a level to the second ability so the player always starts with one attack
        playerStats.AbbiliteLVL[2]++;
        spawnAttacks=FindFirstObjectByType<SpawnAttacks>();
        //closes the menu after setup is done
        CloseMenu();
    }
    private void OnEnable()
    {
        //if the player stats veriable is null. assigns it
        if (playerStats == null) 
        {
            playerStats = FindFirstObjectByType<PlayerStats>();
            playerStats.AbbiliteLVL = new int[Abilites.Length];
        }
        //if the SpawnAttacks veriable is null. assigns it
        if (spawnAttacks == null)
        {
            spawnAttacks = FindFirstObjectByType<SpawnAttacks>();
        }
        //pauses the game
        Time.timeScale = 0f;
        //runs the set options function
        SetOptions();
        //runs the StopCO function
    }
    public void SetOptions()
    {
        //counts the number of abbilitys that are undert the max Level
        int count = 0;
        for (int i = 0; i < Abilites.Length; i++)
        {
            if (playerStats.AbbiliteLVL[i] < 5)
            {
                count++;
            }
        }
        if (count > 0) 
        {

            spawnAttacks.StopCo();
            //if the count is more than 0. creates a new array and assignes all posible abilitys to it
            avalibleAbilitys = new GameObject[count];
            int current = 0;
            for (int i = 0; i < Abilites.Length; i++)
            {
                if (playerStats.AbbiliteLVL[i] < 5)
                {
                    avalibleAbilitys[current] = Abilites[i];
                    current++;
                }

            }
            //picks 3 abilits from this list at random and sets the UI options to match the sprites and name

            for (int i = 0; i < OptionText.Length; i++)
            {
                int ran = Random.Range(0, avalibleAbilitys.Length);
                for (int j = 0; j < Abilites.Length; j++)
                {
                    if (avalibleAbilitys[ran] == Abilites[j])
                    {
                        choices[i] = j;
                    }
                }
                if (Abilites[choices[i]].GetComponent<AttackController>())
                {
                    optionImage[i].sprite = avalibleAbilitys[ran].GetComponent<AttackController>().Sprite;
                    OptionText[i].text = avalibleAbilitys[ran].GetComponent<AttackController>().Name;
                }
                else if (Abilites[choices[i]].GetComponent<ModifierController>())
                {
                    optionImage[i].sprite = avalibleAbilitys[ran].GetComponent<ModifierController>().Sprite;
                    OptionText[i].text = avalibleAbilitys[ran].GetComponent<ModifierController>().Name;
                }
            }
        } //if the count was 0. runs the close menu script
        else if (count <= 0)
        {
            CloseMenu();
        }
        
    }

    //closes the abbility wheel UI element and unpauses the game

    public void CloseMenu()
    {
        playerStats.UpdateLevels();
        RestartAttacks();
        Time.timeScale = 1f;
        gameObject.SetActive(false);    
    }
    // adds a level to the ability that is chosen and runs the CloseMenu script

    public void Choice(int button)
    {
        if (playerStats.AbbiliteLVL[choices[button]] < 5)
        {
            {
               Abilites[choices[button]] = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]) * playerStats.NumberOfAbilitys];
               playerStats.AbbiliteLVL[choices[button]]++;
               CloseMenu();
            }
        }   
    }
    //restarts the attacks spawning
    public void RestartAttacks()
    {
        for(int i = 0; i < playerStats.AbbiliteLVL.Length; i++)
        {
            AttackController currentAbility = Abilites[playerStats.AbbiliteLVL[i]].GetComponent<AttackController>();
            if (playerStats.AbbiliteLVL[i] > 0 && currentAbility !=null)
            {
              spawnAttacks.attackStart(Abilites[i]); 
            }
        }
    }
    //changes the description to match the infromation from the attack being hoverd over
    public void HoverDescription(int button)
    {
        if (button == -1) 
        {
            Name.text ="Name";
            Description.text = "Description";
        }
        else if(playerStats.AbbiliteLVL[choices[button]]+1<5)
        {
            
            if (Abilites[choices[button]].GetComponent<AttackController>() )
            {
                Name.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]+1) * playerStats.NumberOfAbilitys].GetComponent<AttackController>().Name +" LVL:"+ (playerStats.AbbiliteLVL[choices[button]]+1);
                Description.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]+1) * playerStats.NumberOfAbilitys].GetComponent<AttackController>().Description;
                Debug.Log(choices[button] + (playerStats.AbbiliteLVL[choices[button]] + 1) * playerStats.NumberOfAbilitys);
            }else if (Abilites[choices[button]].GetComponent<ModifierController>())
            {
                Name.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]+1) * playerStats.NumberOfAbilitys].GetComponent<ModifierController>().Name + " LVL:" + (playerStats.AbbiliteLVL[choices[button]] + 1);
                Description.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]+1) * playerStats.NumberOfAbilitys].GetComponent<ModifierController>().Description;
            }

        }
        else
        {
            if (Abilites[choices[button]].GetComponent<AttackController>())
            {
                Name.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]) * playerStats.NumberOfAbilitys].GetComponent<AttackController>().Name + " LVL:" + (playerStats.AbbiliteLVL[choices[button]] + 1);
                Description.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]) * playerStats.NumberOfAbilitys].GetComponent<AttackController>().Description;
                Debug.Log(choices[button] + (playerStats.AbbiliteLVL[choices[button]] + 1) * playerStats.NumberOfAbilitys);
            }
            else if (Abilites[choices[button]].GetComponent<ModifierController>())
            {
                Name.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]) * playerStats.NumberOfAbilitys].GetComponent<ModifierController>().Name + " LVL:" + (playerStats.AbbiliteLVL[choices[button]] + 1);
                Description.text = playerStats.Ability[choices[button] + (playerStats.AbbiliteLVL[choices[button]]) * playerStats.NumberOfAbilitys].GetComponent<ModifierController>().Description;
            }
        }
        
    }
   
}
