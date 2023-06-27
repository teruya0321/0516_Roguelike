using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill01 : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ƒXƒLƒ‹1");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            if (GetHp())
            {
                //GetComponent<PlayerMove>().hp++;
                timer = 0;
            }
        }
    }

    bool GetHp()
    {
        return GetComponent<PlayerMove>().hp <= GetComponent<PlayerMove>().defaultHp;
    }
}
