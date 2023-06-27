using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WeaponCSVReader : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();
    // Start is called before the first frame update
    void Awake()
    {
        csvFile = Resources.Load("CSVs/WeaponCSVData") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // ˆês‚¸‚Â“Ç‚İ‚İ
            csvDatas.Add(line.Split(',')); // , ‹æØ‚è‚ÅƒŠƒXƒg‚É’Ç‰Á
        }
    }
}
