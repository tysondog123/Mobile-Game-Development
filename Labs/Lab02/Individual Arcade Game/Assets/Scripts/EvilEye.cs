using UnityEngine;

public class EvilEye : MonoBehaviour
{
    GameObject[] Enemies;
    public bool Recoil;
    public float RecoilDammage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds all gameobjects with the tag Enemy
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //checks if there are more than 3 enemies
        if( Enemies != null && Enemies.Length>3)
        {
            //selects a random enemy from list, deals damage to it and spawns a Eye at its positon
            GameObject selected = Enemies[Random.Range(0, Enemies.Length)];
            selected.GetComponent<HpController>().takeDamage(GetComponent<AttackController>().Damage);
            transform.position = selected.transform.position;
        }

        //if Recoil is true. deals Recoil damage to player
        if (Recoil == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<HpController>().takeDamage(RecoilDammage);
        }
    }
    
}
