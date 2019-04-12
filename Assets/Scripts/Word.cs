using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Word : MonoBehaviour
{
    public GameObject LetterBoxPrefab;

    private WordBase _WordContent;
    public WordBase WordContent
    {
        get { return _WordContent; }
        set
        {
            if (_WordContent != value) {
                Clear();    // 清除旧字母

                _WordContent = value;
                CreateLetters();
            }
        }
    }


    private int NextLetterIndex;

    private List<Letter> LetterList = new List<Letter>();
    private WordPanelBase ParentWordPanel;


    public void Awake() {
        NextLetterIndex = 0;
    }

    // 初始化 依赖于WordBase
    public void Init(WordBase _WordBase, WordPanelBase _ParentWordPanel) {
        WordContent = _WordBase;
        ParentWordPanel = _ParentWordPanel;
    }

    // 初始化 弃用
    public void Init(string wordContent, WordPanelBase parentWordPanel) {
        if (ParentWordPanel == null) {
            WordContent.WordRaw = wordContent;
            ParentWordPanel = parentWordPanel;

            CreateLetters();
        }
    }

    // 创建字母
    private void CreateLetters() {
        for (int i = 0; i < WordContent.Length; i++) {
            // 字母依次放好   // 暂时
            Vector3 pos = transform.position + new Vector3(i, 0, -1);
            GameObject go = Instantiate(LetterBoxPrefab, pos, transform.rotation, transform);

            // Letter初始化
            Letter letter = go.GetComponent<Letter>();
            letter.Init(WordContent.WordRandom[i].ToString(), this);

            // 记录 Letter List
            LetterList.Add(letter);
        }
    }

    // 检查拼写
    public void CheckLetter(Letter letter) {
        // 通知Panel当前选中该单词
        ParentWordPanel.FocusOn(WordContent);

        // 防止拼完重复触发 预防BUG
        if (NextLetterIndex >= WordContent.Length) {
            return;
        }

        // 判断
        if (WordContent.WordRaw[NextLetterIndex].Equals(letter.LetterContent.ToCharArray()[0])) {
            NextLetterIndex++;
            letter.RightChoose();
        }
        else {
            NextLetterIndex = 0;
            ResetLetterStatus();
        }

        // 正确拼完单词
        if (NextLetterIndex >= WordContent.Length) {
            SpellOver();
        }

    }

    // 聚焦单词
    public void OnFocus() {
        ParentWordPanel.FocusOn(WordContent);
    }


    // 拼写正确
    private void SpellOver() {
        ParentWordPanel.ClearWord(WordContent);
    }

    // 重置字母状态
    private void ResetLetterStatus() {
        foreach (Letter letter in LetterList) {
            letter.ResetStatus();
        }
    }

    // 删除字母子物体
    public void Clear() {
        int count = transform.childCount;
        for (int i = count - 1; i >= 0; i--) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

}
