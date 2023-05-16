using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerePortObj : MonoBehaviour
{
    GameObject gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<AreaMove>().NextArea();
        }
    }
}
