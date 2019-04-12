using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Assets.Scripts;

public class WordPanel : WordPanelBase
{
    public WordBar WordBarInstance;

    public List<Word> WordList;
    private List<WordBase> wordBaseList = new List<WordBase>();
    

    public void AddWord(WordBase wordBase) {
        // 单词依次放好   // 暂时
        Vector3 pos = new Vector3(0, WordList.Count, -1);
        GameObject go = Instantiate(WordPrefab, pos, transform.rotation, transform);

        // 单词初始化
        Word word = go.GetComponent<Word>();
        word.Init(wordBase, this);

        // 记录 Word List
        WordList.Add(word);
        wordBaseList.Add(wordBase);
    }

    public void AddWord(string wordContent) {
        // 单词依次放好   // 暂时
        Vector3 pos = new Vector3(0, WordList.Count, -1);
        GameObject go = Instantiate(WordPrefab, pos, transform.rotation, transform);

        // 单词初始化
        Word word = go.GetComponent<Word>();
        word.Init(wordContent, this);

        // 记录 Word List
        WordList.Add(word);
        wordBaseList.Add(word.WordContent);
    }

    // P v C 时 电脑用
    public void ClearWord(int index) {

    }

    public override void ClearWord(WordBase wordBase) {

        // 找到该单词在List中对应的序号
        int index = wordBaseList.FindIndex(delegate (WordBase tmp){
            return wordBase.WordRaw == tmp.WordRaw;
        });

        // 消失动画效果
        WordList[index].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
        WordList[index].transform.DOShakePosition(0.5f, new Vector3(0.5f, 0.5f, 0.5f));
        Destroy(WordList[index].gameObject, 0.5f);   //暂时  

        // List中清除
        WordList.RemoveAt(index);
        wordBaseList.RemoveAt(index);
    }

    public override void FocusOn(WordBase wordBase) {
        WordBarInstance.FocusOn(wordBase);
    }


}
