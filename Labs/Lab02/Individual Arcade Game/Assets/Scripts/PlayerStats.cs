using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int[] AbbiliteLVL;
    public int NumberOfAbilitys;
    public Vector2[] AttackSize;
    public float[] AttackDelay;
    public float[] AttackDamage;
    public float[] SpeedBoost;

    public float[] TeleportDistance;
    public float[] TeleportDelay;

    public float[] HealAmount;
    public float HealDelay;

    public int SizeLVL;
    public int DelayLVL;
    public int DamageLVL;
    public int SpeedLVL;
    public int HealLVL;
    public int TeleportLVL;

    [Header("Abilites")]
    public GameObject[] Ability;

    private void Start()
    {
        StartCoroutine(Heal());
    }
    public void UpdateLevels()
    {
        DelayLVL = AbbiliteLVL[6];
        DamageLVL = AbbiliteLVL[7];
        HealLVL = AbbiliteLVL[8];
        TeleportLVL = AbbiliteLVL[9];
        SizeLVL = AbbiliteLVL[10];
        SpeedLVL = AbbiliteLVL[11];
    }
    IEnumerator Heal()
    {
        //checks if player hp is below its max
        HpController hpController = GetComponent<HpController>();
        if ((hpController.HP + HealAmount[HealLVL]) <= hpController.MaxHp)
        {
            //heals player hp by the heal amount level if result wouldnt go over max
            hpController.HP += HealAmount[HealLVL];
            yield return new WaitForSeconds(HealDelay);
            StartCoroutine(Heal());
        }
        else
        {
            //sets hp to max if it would otherwise go over max hp
            hpController.HP = hpController.MaxHp;
            yield return new WaitForSeconds(HealDelay);
            StartCoroutine(Heal());
        }
        
    }

    
}
