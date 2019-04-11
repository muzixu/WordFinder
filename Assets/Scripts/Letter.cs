using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Letter : MonoBehaviour
{



    private void Update()
    {
           
    }

    // 字母 get set 
    private string letterContent;
    public string LetterContent
    {
        get
        {
            return letterContent;
        }
        set
        {
            letterContent = value;
            LetterTextMesh.text = value;
        }
    }


    public TextMesh LetterTextMesh;

    private Word ParentWord;


    // 初始化赋值父物体 Word
    public void Init(string letter, Word parentWord) {
        if (ParentWord == null) {
            LetterContent = letter;
            parentWord = ParentWord = parentWord;
        }
    }

    // 点击到该字母
    public void OnTouch() {
        ParentWord.CheckLetter(LetterContent);
        Tweener w = this.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.5f);
        w.SetEase(Ease.Linear);
        w.SetLoops(-1, LoopType.Yoyo);
        // ... to do: 改变颜色以提示

    }

    //重置状态
    public void ResetStatus()
    {

    }

}
