using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Letter : MonoBehaviour
{
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
    private Tweener RightChooseTweener;


    public void Start() {
        RightChooseTweener = transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.5f);
        RightChooseTweener.SetEase(Ease.Linear);
        RightChooseTweener.SetLoops(-1, LoopType.Yoyo);
        RightChooseTweener.Pause();
    }


    // 初始化赋值父物体 Word
    public void Init(string letter, Word parentWord) {
        if (ParentWord == null) {
            LetterContent = letter;
            parentWord = ParentWord = parentWord;
        }
    }

    // 点击到该字母
    public void OnTouch() {
        ParentWord.CheckLetter(this);
        
        // ... to do: 改变颜色以提示

    }

    // 点击该单词
    public void OnTouchAll() {
        ParentWord.OnFocus();
    }

    // 选则正确的效果
    public void RightChoose() {
        RightChooseTweener.Play();
    }

    //重置状态
    public void ResetStatus()
    {
        RightChooseTweener.Restart();
        RightChooseTweener.Pause();
    }

}
