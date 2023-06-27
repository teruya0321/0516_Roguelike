using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform enemyBox;

    public bool boss;
    public void CallEnemy()
    {        
        int i = Random.Range(1,5);

        GameObject enemy = (GameObject)Resources.Load("TestForder/Enemy0" + i);

        Instantiate(enemy,this.transform.position,Quaternion.identity,enemyBox);
    }

    public void BossCallEnemy(int bossNumber)
    {
        GameObject bossEnemy = (GameObject)Resources.Load("TestForder/BossEnemy0" + bossNumber);

        Instantiate(bossEnemy, transform.position, Quaternion.identity, enemyBox);
    }
}
