using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeponsSwap : MonoBehaviour
{
    
    [SerializeField]
    FollowCursor followCursor;
    public void Sawp(GameObject Wepon)
    {
        followCursor.Projectile = Wepon;
    }
   
    
}
