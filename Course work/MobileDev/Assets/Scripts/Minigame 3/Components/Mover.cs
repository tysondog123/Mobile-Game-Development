using System.Collections;
using UnityEngine;

class Mover : Component
{
    [SerializeField]
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        GetComponent<SpriteRenderer>().sprite = sprite;
        StartCoroutine(ProccesTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ProccesTime()
    {
        Debug.Log(Activate());
        yield return new WaitForSeconds(1);
        StartCoroutine(ProccesTime());
    }
    public override int Activate()
    {
        if ((transform.position + direction).x > gridManager.GetGridSize().x-1 || (transform.position + direction).x <0)
        {
            direction = -direction;
            return 1;
        }
        transform.position += direction;
        return 0;
    }
}
