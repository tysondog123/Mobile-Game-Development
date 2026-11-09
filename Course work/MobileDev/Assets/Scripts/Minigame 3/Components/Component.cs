using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

abstract class Component : MonoBehaviour
{
    protected GridManager gridManager;
    [SerializeField]
    string ComponentName;
    [SerializeField]
    protected Sprite sprite;
    [SerializeField]
    int UID;
    protected Vector2 handDirection = new Vector2(0f,1f);
    GameObject Resource;
    int priorityOrder =0;

    private void Start()
    {
        gridManager  = FindFirstObjectByType<GridManager>();
        GetComponent<SpriteRenderer>().sprite = sprite;
        StartCoroutine(ProccesTime());
    }
    public IEnumerator ProccesTime()
    {
        yield return new WaitForSeconds(1);
        Activate();
        StartCoroutine(ProccesTime());
    }
    public abstract int Activate();
}
