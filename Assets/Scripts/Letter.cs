using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{



    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //从摄像机发出到点击坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if(Physics.Raycast(ray,out hitinfo))
            {
                GameObject templetter = hitinfo.collider.gameObject;
                if(templetter.tag=="letter")
                {
                    OnTouch();
                }
            }
        }
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

        // ... to do: 改变颜色以提示

    }

    //重置状态
    public void ResetStatus()
    {

    }

}
