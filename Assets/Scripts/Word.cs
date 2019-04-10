using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

    public string WordContent;
    public List<Letter> LetterList;
    public GameObject LetterBoxPrefab;

    private int NextWordIndex;
    [SerializeField]
    private WordPanel ParentWordPanel;


    public void Init(string wordContent, WordPanel parentWordPanel) {
        if (ParentWordPanel == null) {
            // 内容赋值
            WordContent = wordContent;
            ParentWordPanel = parentWordPanel;

            // 初始化字母
            NextWordIndex = 0;
            CreateLetters();
        }
    }

    private void CreateLetters() {
        for(int i = 0; i < WordContent.Length; i++) {
            // 字母依次放好   // 暂时
            Vector3 pos = transform.position + new Vector3(i, 0, -1);
            GameObject go = Instantiate(LetterBoxPrefab, pos, transform.rotation, transform);

            // Letter初始化
            Letter letter = go.GetComponent<Letter>();
            letter.Init(WordContent[i].ToString(), this);

            // 记录 Letter List
            LetterList.Add(letter);
        }
    }

    public void CheckLetter(string letter) {

    }

    public void SpellOver() {

    }

}
