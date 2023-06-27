using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyCSVReader : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();// CSVの中身を入れるリスト;
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
}
