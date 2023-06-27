using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill04 : MonoBehaviour
{
    string keyName4;

    float timer;

    bool isCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ÉXÉLÉã4");
        keyName4 = GetComponent<KeyInputSetting>().keyInput[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolDown)
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKeyDown(keyName4))
        {
            RandomWeapon();
            timer = 0;
            isCoolDown = true;
        }
        if (timer >= 30)
        {
            isCoolDown = false;
        }
    }

    void RandomWeapon()
    {

    }
}
