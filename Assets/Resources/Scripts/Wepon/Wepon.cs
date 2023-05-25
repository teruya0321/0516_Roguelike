using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public int weponNumber;
    public void Attack(int i)
    {
        switch (weponNumber)
        {
            case 1:
                Debug.Log("çUåÇíÜ");
                break;

            default:
                break;
        }    
    }
}
