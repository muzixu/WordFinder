using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour {

    public List<Word> WordList;


    public void AddWord(string word) {
        Word NewWord = new Word();
        NewWord.Init(word, this);
        WordList.Add(NewWord);
    }

    public void AddMistakeWord(string mistakeWord) {

    }

    // P v C 时 电脑用
    public void ClearWord(int index) {
        
    }

    public void ClearWord(Word word) {
        WordList.Remove(word);
        // ... to do: 消失效果等

    }
    

}
