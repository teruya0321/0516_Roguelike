using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITest : MonoBehaviour
{
    GameObject targetObj;

    Transform target;

    NavMeshAgent agent;
    // Start is called before the first frame update
    private void Awake()
    {
        targetObj = GameObject.Find("Player");

        target = targetObj.transform;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
