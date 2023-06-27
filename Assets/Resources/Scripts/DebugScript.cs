using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int i = Random.Range(0, 11);
            DebugButton(i);
        }
    }

    public void DebugButton(int i)
    {
        string number = i.ToString("00000");
        //Debug.Log(number);
        //Debug.Log(gameObject);
        if(number[number.Length - 1] == '0'|| number[number.Length - 1] == '5')
        {
            Debug.Log(number + "は5の倍数だよ！");
        }
        else
        {
            Debug.Log(number + "は5の倍数じゃないよ！");
        }
    }
}
