using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public List<GameObject> enemyList;
    public GameObject tereportObj;
    TerePortObj tereport;

    void Start()
    {
        tereport = tereportObj.GetComponent<TerePortObj>();
    }
    public void GetScript(TerePortObj getTereport)
    {
        tereport = getTereport;
    }
    public void AddEnemyList(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void DestroyEnemyList(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

    private void LateUpdate()
    {
        if(enemyList.Count == 0)
        {
            tereport.warpCount = true;
        }
        else
        {
            tereport.warpCount = false;
        }
    }
}
