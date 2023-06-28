using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill05 : MonoBehaviour
{
    string keyName5;

    float timer;

    bool isCoolDown = false;
    Transform mutekiArea;
    GameObject mutekiObj;
    // Start is called before the first frame update
    void Start()
    {
        keyName5 = GetComponent<KeyInputSetting>().keyInput[4];

        Debug.Log("ÉXÉLÉã5");
        mutekiArea = transform.Find("MutekiArea");
        mutekiObj = mutekiArea.gameObject;
        //mutekiObj.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolDown)
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKeyDown(keyName5))
        {
            Muteki();
            timer = 0;
            isCoolDown = true;
        }
        if (timer >= 30)
        {
            isCoolDown = false;
        }
    }

    IEnumerator Muteki()
    {
        mutekiObj.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(5);

        mutekiObj.GetComponent<BoxCollider>().enabled = false;
    }
}
