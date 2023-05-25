using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSkill : MonoBehaviour
{
    public GameObject canvas;

    GameObject uiObj;

    public GameObject gameManager;
    private void Awake()
    {
        uiObj = (GameObject)Resources.Load("UI/SkillButton");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(uiObj);
    }

    // Update is called once per frame

    public void GetSkill()
    {
        uiObj.AddComponent<TestSkill>();
        //Debug.Log("‚Ä‚·‚Æ");
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(uiObj, canvas.transform.Find("Skill"));
        }
    }
}
