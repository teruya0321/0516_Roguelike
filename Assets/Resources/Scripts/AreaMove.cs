using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaMove : MonoBehaviour
{

    public GameObject[] tereportPoint;

    int stage = 3;

    public Image loadingImage;

    GameObject main;

    float timer;

    int imageAlpha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadingImage.GetComponent<Image>().color = new Color(300, 300, 300, imageAlpha);
    }

    public void NextArea(GameObject player,int stage)
    {
        main = player;

        switch (stage)
        {
            case 0:
                player.transform.position = tereportPoint[0].transform.position + transform.forward;
                break;
            case 1:
                player.transform.position = tereportPoint[1].transform.position + transform.forward;
                break;
            case 2:
                player.transform.position = tereportPoint[2].transform.position + transform.forward;
                break;

            default:
                break;
        }
    }
}
