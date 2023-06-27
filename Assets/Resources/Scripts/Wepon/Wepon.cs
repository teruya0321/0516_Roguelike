using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public int weponNumber;
    public void Attack(int i,GameObject enemy)
    {

        switch (i)
        {
            case 1:
                Destroy(enemy.gameObject);
                break;

            default:
                break;
        }    
    }
}
