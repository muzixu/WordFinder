using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

    public string LetterContent;

    private Word ParentWord;


    // 初始化赋值父物体 Word
    public void Init(Word parentWord) {
        if (ParentWord = null) {
            parentWord = ParentWord = parentWord;
        }
    }

    // 点击到该字母
    public void OnTouch() {
        ParentWord.CheckLetter(LetterContent);
        // ... to do: 改变颜色以提示

    }

}
