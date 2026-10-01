using UnityEngine;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    [SerializeField]
    float HP;
    public bool IsPlayer;
    public void DealDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            if (IsPlayer)
            {
                SceneManager.LoadScene("Lose");
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
    public string GetHP() 
    {
        return HP.ToString();
    }

}
