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
    Vector2 handDirection = new Vector2(0f,1f);
    GameObject Resource;
    int priorityOrder =0;

    private void Start()
    {
        gridManager  = FindFirstObjectByType<GridManager>();
    }
    public abstract int Activate();
}
