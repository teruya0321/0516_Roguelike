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
            Debug.Log(number + "‚Í5‚Ì”{”‚¾‚æI");
        }
        else
        {
            Debug.Log(number + "‚Í5‚Ì”{”‚¶‚á‚È‚¢‚æI");
        }
    }
}
