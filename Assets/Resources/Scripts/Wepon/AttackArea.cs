using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = transform.root.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyStatus>().hp -= player.GetComponent<Weapon01>().Attack();
            Debug.Log(other.GetComponent<EnemyStatus>().hp);
        }
    }
}
