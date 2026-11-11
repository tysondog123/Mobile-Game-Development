using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class productionManger : MonoBehaviour
{
    int current=0;
    MiniGame3Manager manager;
    List<GameObject> Components = new List<GameObject>();
    private void Start()
    {
        manager = FindFirstObjectByType<MiniGame3Manager>();
    }
    public void startProduction()
    {
        Components = manager.gridManager.GetList();
        StartCoroutine(Productuion());
    }
    IEnumerator Productuion()
    {
        Components[current].GetComponent<Component>().Activate();
        yield return new WaitForSeconds(.5f);
        current++;
        if (current+1 > Components.Count)
        {
            current = 0;
        }

        StartCoroutine(Productuion());
    }
}
