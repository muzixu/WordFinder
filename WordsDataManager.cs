using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Linq;
public class WordsDataManager : MonoBehaviour
{
    public enum GameLevel { easy, medium,hard};
    public List<WordsDataItem> DataList;
    public Text showText;
    public string fileName;
    private WordsData loadedData;
    // Use this for initialization
    void Start()
    {
    }
    public string LevelStatus(GameLevel level)
    {
        if (level == GameLevel.easy)   return "cet4.json"; else
        if (level == GameLevel.medium) return "cet6.json"; else 
        return "ky.json";
    }
    public void LoadData(GameLevel level)//加载数据库数据到loadedData中
    {
        fileName = LevelStatus(level);
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log(filePath);
        string dataAsJson = File.ReadAllText(filePath); //读取所有数据送到json格式的字符串里面。
        Debug.Log(dataAsJson);
        showText.text = "";
        loadedData = JsonUtility.FromJson<WordsData>(dataAsJson);
        DataList = loadedData.items.OfType<WordsDataItem>().ToList();
       /* foreach (WordsDataItem s in DataList)
        {
            showText.text += s.word + "\n";
        }*/
        Debug.Log("共有" + DataList.Count + "条目");     
    }

    public void DeleteData(string key)//清除单词（关键字）
    {
        if (DataList!=null && DataList.Count > 0)
        {
            for (int i = 0; i <= DataList.Count; i++)
            {
                if (DataList[i].word == key) DataList.RemoveAt(i);
            }
            OutData();
        }
    }

    public void OutData()//输出到表中
    {
        
        loadedData.items = DataList.ToArray<WordsDataItem>();
        string jsonAsData = JsonUtility.ToJson(loadedData);
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        FileInfo file = new FileInfo(filePath);
        StreamWriter sw = file.CreateText();

        //test
       // showText.text = "";
        /* for (int i = 0; i < loadedData.items.Length; i++)
             {
                 showText.text += loadedData.items[i].word + "\n";
             }*/


        sw.WriteLine(jsonAsData);
        sw.Close();
        sw.Dispose();

    }

    public WordsDataItem GetWords()//获得表中的随机单词
    {
        if (DataList!=null && DataList.Count > 0)
        {
            System.Random rd = new System.Random();
            return DataList[rd.Next(DataList.Count)];
        }
        else return new WordsDataItem();
    }

    public void AddWrongWord(WordsDataItem wrong)//添加错题库
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "wrong.json");
        Debug.Log(filePath);
        string dataAsJson = File.ReadAllText(filePath); //读取所有数据送到json格式的字符串里面。
        Debug.Log(dataAsJson);
        showText.text = "";
        loadedData = JsonUtility.FromJson<WordsData>(dataAsJson);
        DataList = loadedData.items.OfType<WordsDataItem>().ToList();
        DataList.Add(wrong);
        OutData();
    }
}
    

