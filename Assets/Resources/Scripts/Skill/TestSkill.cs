using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkill : MonoBehaviour
{
    GameObject skillParent;

    public int number;
    // Start is called before the first frame update

    private void Awake()
    {
        skillParent = transform.parent.gameObject;
    }
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(CallDestroyButton);
        //Debug.Log(skillNumber);
    }

    public void CallDestroyButton()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMove>().loading = false;
        if (number <= 5)
        {
            if (player.GetComponent(System.Type.GetType("Skill0" + number)) == null)
            {
                player.AddComponent(System.Type.GetType("Skill0" + number));
            }
        }
        else
        {
            if(player.GetComponent<Weapon01>().GetWeaponNumber() != number)
            {
                player.GetComponent<Weapon01>().ChangeWeapon(number - 5);
            }
            else
            {
                player.GetComponent<PlayerStatus>().StatusUp(Random.Range(1, 4));
            }
        }
        skillParent.gameObject.GetComponent<DestroyButton>().AllDestroyButton();
    }

    private void OnDisable()
    {
        Destroy(GetComponent<TestSkill>());
    }
}
