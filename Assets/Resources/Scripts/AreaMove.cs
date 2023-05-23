using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaMove : MonoBehaviour
{

    public GameObject[] tereportPoint;

    public Image loadingImage;

    GameObject main;

    //float timer;

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
        player.transform.position = tereportPoint[stage].transform.position + transform.forward;
        StartCoroutine("LoadingImage");
    }

    IEnumerator LoadingImage()
    {
        main.GetComponent<PlayerMove>().loading = true;
        imageAlpha = 255;
        //Debug.Log(loadingImage.GetComponent<Image>().color);

        yield return new WaitForSeconds(3);

        main.GetComponent<PlayerMove>().loading = false;
        imageAlpha = 0;
        //Debug.Log(loadingImage.GetComponent<Image>().color);
    }
}