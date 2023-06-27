using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyCSVReader : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();// CSV�̒��g�����郊�X�g;
    private void Awake()
    {
        csvFile = Resources.Load("TestForder/EnemyTest") as TextAsset;// Resouces����CSV�ǂݍ���

        StringReader reader = new StringReader(csvFile.text);
        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�s
        }
    }
}
