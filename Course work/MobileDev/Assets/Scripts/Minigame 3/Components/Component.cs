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
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public int GetUID()
    {
        return UID;
    }
    public abstract int Activate();
}
