using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WordPanel : MonoBehaviour {

    public List<Word> WordList;

    public GameObject WordPrefab;


    public void AddWord(string wordContent) {
        // 单词依次放好   // 暂时
        Vector3 pos = new Vector3(0, WordList.Count, -1);
        GameObject go = Instantiate(WordPrefab, pos, transform.rotation, transform);

        // 单词初始化
        Word word = go.GetComponent<Word>();
        word.Init(wordContent, this);

        // 记录 Word List
        WordList.Add(word);
    }

    public void AddMistakeWord(string mistakeWord) {

    }

    // P v C 时 电脑用
    public void ClearWord(int index) {
        
    }

    public void ClearWord(Word word) {
        Debug.Log("执行ClearWord");
        word.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
        word.transform.DOShakePosition(0.5f, new Vector3(0.5f, 0.5f, 0.5f));
        WordList.Remove(word);
        Destroy(word.gameObject);   //暂时  

        // ... to do: 消失效果等

    }
    

}
