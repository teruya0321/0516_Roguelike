using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    GameObject enemy;

    public void CallEnemy()
    {
        int i = Random.Range(0, 1);

        enemy = (GameObject)Resources.Load("TestForder/Enemy");

        Instantiate(enemy,this.transform.position,Quaternion.identity);
    }
}
