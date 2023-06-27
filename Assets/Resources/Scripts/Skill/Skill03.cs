using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill03 : MonoBehaviour
{
    string keyName3;

    float timer;

    bool isCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ÉXÉLÉã3");
        keyName3 = GetComponent<KeyInputSetting>().keyInput[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolDown)
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKeyDown(keyName3))
        {
            StartCoroutine(UpAtk());
            timer = 0;
            isCoolDown = true;
        }
        if(timer >= 30)
        {
            isCoolDown = false;
        }

    }

    IEnumerator UpAtk()
    {
        yield return new WaitForSeconds(10);
    }
}
