using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skill02 : MonoBehaviour
{
    string keyName2 = "2";

    Transform enemyBox;

    bool isCoolDown = false;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        enemyBox = GameObject.Find("Enemys").transform;
        keyName2 = GetComponent<KeyInputSetting>().keyInput[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolDown)
        {
            timer += Time.deltaTime;
        }
        else if(Input.GetKeyDown(keyName2))
        {
            StartCoroutine(DownSpeed());
            timer = 0; 
            isCoolDown = true;
        }
        if(timer >= 40)
        {
            isCoolDown = false;
        }
    }

    IEnumerator DownSpeed()
    {

        foreach (Transform childEnemy in enemyBox)
        {
            childEnemy.gameObject.GetComponent<NavMeshAgent>().speed /= 2;
        }

        yield return new WaitForSeconds(10);

        foreach (Transform childEnemy in enemyBox)
        {
            childEnemy.gameObject.GetComponent<NavMeshAgent>().speed *= 2;
        }
    }
}
