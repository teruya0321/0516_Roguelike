using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AddSkill : MonoBehaviour
{
    public GameObject canvas;

    public GameObject uiObj;

    public GameObject gameManager;

    public List<Sprite> uiIcon;

    int end = 13;

    public List<int> numbers;
    public void GetSkill()
    {
        numbers = new List<int>(); 
        for (int i = 1; i <= end; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i <= 2; i++)
        {
            int y = Random.Range(1, numbers.Count);
            int ransu = numbers[y];

            numbers.RemoveAt(y);

            uiObj.GetComponent<TestSkill>().number = ransu;
            uiObj.GetComponent<Image>().sprite = uiIcon[ransu - 1];
            Instantiate(uiObj, canvas.transform.Find("ButtonParent"));
        }

    }
}
