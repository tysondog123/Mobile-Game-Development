using System.Collections;
using UnityEngine;

class Mover : Component
{
    [SerializeField]
    Vector3 direction;
    public override int Activate()
    {
        if ((transform.position + direction).x > gridManager.GetGridSize().x-1 || (transform.position + direction).x <0)
        {
            direction = -direction;
        }
        if(gridManager.MoveOnGrid(transform.position,transform.position + direction) == 1)
        {
            direction = -direction;

            if (gridManager.MoveOnGrid(transform.position, transform.position + direction) == 1)
            {
                Destroy(gameObject);
            }
        }
        return 0;
    }
}
