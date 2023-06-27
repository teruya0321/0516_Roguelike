using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;
    
    public int defaultHp;
    public int hp;

    public bool loading = false;

    float x;

    float z;

    float defaultspeed;

    public GameObject weapon;

    //Rigidbody myRb;
    // Start is called before the first frame update
    void Start()
    {
        defaultspeed = speed;
        hp = defaultHp;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;

        z = Input.GetAxisRaw("Vertical") * speed;

        Vector3 movement = new Vector3(x, -2, z);
        /*if(myRb.velocity.magnitude < maxSpeed)
        {
            myRb.AddForce(movement);
        }*/
        gameObject.GetComponent<Rigidbody>().velocity = movement;
        if (loading)
        {
            speed = 0;
        }
        else
        {
            speed = defaultspeed;
        }

        if(x != 0 || z != 0)   
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion rotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, toRotation, 0.15f);
            GetComponent<Rigidbody>().MoveRotation(rotation);
        }
    }
}
