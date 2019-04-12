using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Assets.Scripts;

public class WordBar : WordPanelBase
{
    public WordPanel WordPanelInstance;
    public Word CurrentWord;

    public void UpdateWord(WordBase wordBase) {
        // 清除旧单词
        if (CurrentWord != null) {
            CurrentWord.Clear();

            int count = transform.childCount;
            for (int i = 0; i < count; i++) {
                Destroy(transform.GetChild(0).gameObject);
            }
        }

        AddWord(wordBase);
    }

    public void AddWord(WordBase wordBase) {
        // 单词依次放好   // 暂时
        GameObject go = Instantiate(WordPrefab, transform.position, transform.rotation, transform);

        // 单词初始化
        Word word = go.GetComponent<Word>();
        word.Init(wordBase, this);

        // 记录 Word
        CurrentWord = word;
    }

    public void AddMistakeWord(WordBase wordBase) {

    }

    public override void ClearWord(WordBase wordBase) {
        if (CurrentWord == null) {
            return;
        }

        // 消失动画效果
        CurrentWord.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
        CurrentWord.transform.DOShakePosition(0.5f, new Vector3(0.5f, 0.5f, 0.5f));
        Destroy(CurrentWord.gameObject, 0.5f);   //暂时  

        CurrentWord = new Word();

        // 在WordPanel中也清除
        WordPanelInstance.ClearWord(wordBase);
    }

    public override void FocusOn(WordBase wordBase) {
        if (CurrentWord.WordContent != wordBase) {
            UpdateWord(wordBase);
        }
    }

}
