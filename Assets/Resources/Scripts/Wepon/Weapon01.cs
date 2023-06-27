using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Weapon01 : MonoBehaviour
{
    PlayerStatus playerStatus;
    public GameObject attackRange;

    int weaponNumber = 1;

    int myMinAtk;
    int myMaxAtk;

    int atk;

    public int myMinHp;
    public int myMaxHp;

    public float myMinSpeed;
    public float myMaxSpeed;

    public float myAttackRange;
    public bool myAttackType;
    public float myAttackSpeed;

    float timer;

    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();// CSVの中身を入れるリスト;
    private void Awake()
    {
        csvFile = Resources.Load("TestForder/WeaponTest") as TextAsset;// Resouces下のCSV読み込み

        StringReader reader = new StringReader(csvFile.text);
        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加s
        }
    }

    private void OnEnable()
    {
        playerStatus = GetComponent<PlayerStatus>();
        if(PlayerPrefs.GetInt("PlayerHaveWeapon") != 0)
        {
            ChangeWeapon(PlayerPrefs.GetInt("PlayerHaveWeapon"));
        }
        else
        {
            ChangeWeapon(1);
        }
        
    }
    void Update()
    {
        if (!myAttackType) timer += Time.deltaTime;

        if (myAttackType && Input.GetButtonDown("Fire1"))
        {
            attackRange.GetComponent<BoxCollider>().enabled = true;
        }
        else if (timer >= myAttackSpeed)
        {
            attackRange.GetComponent<BoxCollider>().enabled = true;
            timer = 0;
        }
        else
        {
            attackRange.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public int GetWeaponNumber()
    {
        return weaponNumber;
    }
    public void ChangeWeapon(int weaponNum)
    {
        Debug.Log("武器をWeapon0" + weaponNum + "に切り替えたよ！");

        myMinAtk = int.Parse(csvDatas[weaponNum][2]);
        myMaxAtk = int.Parse(csvDatas[weaponNum][3]);

        atk = myMinAtk;

        myMinHp = int.Parse(csvDatas[weaponNum][4]);
        myMaxHp = int.Parse(csvDatas[weaponNum][5]);

        myMinSpeed = float.Parse(csvDatas[weaponNum][6]);
        myMaxSpeed = float.Parse(csvDatas[weaponNum][7]);

        myAttackRange = float.Parse(csvDatas[weaponNum][8]);
        myAttackType = bool.Parse(csvDatas[weaponNum][9]);
        if (!myAttackType)
        {
            myAttackSpeed = float.Parse(csvDatas[weaponNum][10]);
        }

        attackRange.transform.localScale = new Vector3(1, 1, myAttackRange);

        playerStatus.SetPlayerStatus(myMinHp,myMinSpeed);

        PlayerPrefs.SetInt("PlayerHaveWeapon", weaponNum);
    }

    public int Attack()
    {
        return atk;
    }

    public void UpAtk()
    {
        atk++;
        Mathf.Clamp(atk, myMinAtk, myMaxAtk);

        PlayerPrefs.SetInt("UpAtk", atk -= myMinAtk + PlayerPrefs.GetInt("UpAtk"));
    }
}
