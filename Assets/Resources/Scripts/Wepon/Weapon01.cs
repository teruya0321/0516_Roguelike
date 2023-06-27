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
    List<string[]> csvDatas = new List<string[]>();// CSV�̒��g�����郊�X�g;
    private void Awake()
    {
        csvFile = Resources.Load("TestForder/WeaponTest") as TextAsset;// Resouces����CSV�ǂݍ���

        StringReader reader = new StringReader(csvFile.text);
        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�s
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
        Debug.Log("�����Weapon0" + weaponNum + "�ɐ؂�ւ�����I");

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
