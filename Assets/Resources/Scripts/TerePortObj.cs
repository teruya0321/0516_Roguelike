using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerePortObj : MonoBehaviour
{
    GameObject gameManager;

    public bool warpCount;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && warpCount)
        {
            GameObject player = collision.gameObject;
            int stage = Random.Range(0, 3);
            Random.InitState(System.DateTime.Now.Millisecond);
            gameManager.GetComponent<AreaMove>().NextArea(player,stage);
        }
    }
}
