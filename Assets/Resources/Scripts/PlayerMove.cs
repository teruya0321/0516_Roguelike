using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;

    public bool loading = false;

    float x;

    float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loading)
        {
            x = 0;

            z = 0;
        }
        else
        {
            x = Input.GetAxisRaw("Horizontal") * speed;

            z = Input.GetAxisRaw("Vertical") * speed;

        }

        if (x != 0 || z != 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, -2, z);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -2, 0);
        }
        
    }
}
