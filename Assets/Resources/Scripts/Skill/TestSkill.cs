using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkill : MonoBehaviour
{
    GameObject skillParent;
    // Start is called before the first frame update

    private void Awake()
    {
        skillParent = transform.parent.gameObject;
    }
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(CallDestroyButton);
    }

    public void CallDestroyButton()
    {
        skillParent.gameObject.GetComponent<DestroyButton>().AllDestroyButton();

        GameObject.Find("Player").GetComponent<PlayerMove>().loading = false;
    }

}
