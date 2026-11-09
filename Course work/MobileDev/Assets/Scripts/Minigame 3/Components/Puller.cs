using UnityEngine;

class Puller : Component
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override int Activate()
    {
        if(gridManager.GetObjectAtIndex((Vector2)transform.position + (handDirection) * 2) != null)
        {
            GameObject _pushObject = gridManager.GetObjectAtIndex((Vector2)transform.position + (handDirection) * 2);
            gridManager.MoveOnGrid((Vector2)_pushObject.transform.position, (Vector2)_pushObject.transform.position - handDirection);
            return 1;
        }
        else
        {
            Debug.Log("No object at location");
            return 1;
        }
        
    }
}
