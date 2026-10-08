using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAttacks : MonoBehaviour
{
    //starts all attacks when run
    public void attackStart(GameObject InputAttack)
    {
        StartCoroutine(SpawnAttack(InputAttack));
    }

    //controlls the spawn of attacks
    public IEnumerator SpawnAttack(GameObject InputAttack )
    {
        GameObject SpawnedAttack;
        //checks if the input prefab has a AttackController Script
        if (InputAttack.GetComponent<AttackController>())
        {
            //sets the attackController veriable to be the prefabls attackController
            AttackController attackController = InputAttack.GetComponent<AttackController>();
             //waits for amount of time equal to the delay veriable multiplied by the delay modifier
            yield return new WaitForSeconds(attackController.Delay * GetComponent<PlayerStats>().AttackDelay[GetComponent<PlayerStats>().DelayLVL]);
            //spawns a number of attacks equal to the attack amount veriable
            for (int i = 0; i < attackController.attackAmount; i++)
            {
                //spawns a attack at the playes position plus the current movement angle in the array and sets it to the spawned attack veriable
               SpawnedAttack = Instantiate(InputAttack, transform.position + attackController.Angle[i], Quaternion.identity);
               // sets the spawned attacks speed to be equal to the current angle in the array multiplied by its speed veriable
               SpawnedAttack.GetComponent<AttackController>().DirectionOfMovement = attackController.Angle[i] * InputAttack.GetComponent<AttackController>().Speed;
               
            }
            //restarts the attack spawn function
            StartCoroutine(SpawnAttack(InputAttack));
        }
        
    }
    //stops all attacks
    public void StopCo()
    {
        StopAllCoroutines();
    }
}
