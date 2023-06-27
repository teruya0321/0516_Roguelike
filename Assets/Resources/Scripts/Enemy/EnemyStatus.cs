using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class EnemyStatus : MonoBehaviour
{
    public GameObject target;

    NavMeshAgent agent;
    int tagNumber;

    public int hp;
    public int atk;
    float speed;
    bool longRange;

    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();// CSVの中身を入れるリスト;

    float atkTimer;
    private void Awake()
    {
        csvFile = Resources.Load("TestForder/EnemyTest") as TextAsset;// Resouces下のCSV読み込み

        StringReader reader = new StringReader(csvFile.text);
        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加s
        }

    }
    private void OnEnable()
    {
        string[] nameNumber = gameObject.name.Split('0', '(');
        tagNumber = int.Parse(nameNumber[1]);

        target = GameObject.Find("Player");

        transform.parent.gameObject.GetComponent<EnemyCount>().AddEnemyList(gameObject);
    }
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        atk = int.Parse(csvDatas[tagNumber][2]);
        hp = int.Parse(csvDatas[tagNumber][3]);
        speed = float.Parse(csvDatas[tagNumber][4]);
        longRange = bool.Parse(csvDatas[tagNumber][5]);

        if (longRange)
        {
            agent.stoppingDistance = 15;
        }
        else
        {
            agent.stoppingDistance = 5;
        }

        if(speed != 0) agent.speed *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);

        Ray ray = new Ray(transform.position, transform.forward * agent.stoppingDistance);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, transform.forward * agent.stoppingDistance, Color.blue);
        if (agent.velocity.magnitude <= 0 && (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Player"))
        {
            PlayerAttacked(hit.transform.gameObject);
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        transform.parent.gameObject.GetComponent<EnemyCount>().DestroyEnemyList(gameObject);
    }

    void PlayerAttacked(GameObject player)
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= 1)
        {
            Debug.Log("攻撃中");
            player.GetComponent<PlayerStatus>().playerHp -= atk;
            atkTimer = 0;
        }
    }
}
