using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButton : MonoBehaviour
{
    public void AllDestroyButton()
    {
        foreach (Transform c in gameObject.transform)
        {
            Destroy(c.gameObject);
        }
    }
}
