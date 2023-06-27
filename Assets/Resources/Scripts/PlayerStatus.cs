using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int playerHp;
    public float playerSpeed;

    int upHp;
    float upSpeed;

    public Weapon01 weaponScript;

    public bool bossArea;
    public void SetPlayerStatus(int minHp,float minSpeed)
    {
        playerHp = minHp + PlayerPrefs.GetInt("UpHp");
        playerSpeed = minSpeed + PlayerPrefs.GetFloat("UpSpeed");
    }

    private void Update()
    {
        if(playerHp <= 0)
        {
            if (bossArea) BossDead();
            else PlayerDead();
        }
    }

    public void StatusUp(int random)
    {
        switch (random)
        {
            case 1:
                playerHp++;
                upHp++;
                Mathf.Clamp(playerHp, weaponScript.myMinHp, weaponScript.myMaxHp);
                break;

            case 2:
                playerSpeed *= 1.1f;
                upSpeed *= 1.1f;
                Mathf.Clamp(playerSpeed, weaponScript.myMinSpeed, weaponScript.myMaxSpeed);
                break;
            case 3:
                weaponScript.UpAtk();
                break;
        }
    }

    void PlayerDead()
    {
        PlayerPrefs.SetInt("UpHp", upHp + PlayerPrefs.GetInt("UpHp"));
        PlayerPrefs.SetFloat("UpSpeed", upSpeed + PlayerPrefs.GetFloat("UpSpeed"));
    }

    void BossDead()
    {
        PlayerPrefs.DeleteAll();
    }
}
    
