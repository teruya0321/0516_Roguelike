using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;

    public bool loading = false;

    float x;

    float z;

    float defaultspeed;

    public GameObject wepon;

    Wepon weponScript;
    // Start is called before the first frame update
    void Start()
    {
        defaultspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;

        z = Input.GetAxisRaw("Vertical") * speed;

        Vector3 movement = new Vector3(x, 0, z);

        gameObject.GetComponent<Rigidbody>().velocity = movement;
        if (loading)
        {
            speed = 0;
        }
        else
        {
            speed = defaultspeed;
        }

        if(movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion rotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, toRotation, 0.15f);
            GetComponent<Rigidbody>().MoveRotation(rotation);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                //Debug.Log("Hit!:" + hit.collider.gameObject);
            }
        }

        if(wepon != null)
        {
            CallWepon();
        }
    }

    void CallWepon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weponScript = GetComponent<Wepon>();

            weponScript.Attack(1);
        }
    }
}
