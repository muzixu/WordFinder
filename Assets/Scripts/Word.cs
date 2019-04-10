using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

    public string WordContent;
    public List<Letter> LetterList;

    private int NextWordIndex;
    private WordPanel ParentWordPanel;


    public void Init(string wordContent, WordPanel parentWordPanel) {
        if (ParentWordPanel = null) {
            WordContent = wordContent;
            ParentWordPanel = parentWordPanel;
        }
    }

    public void CheckLetter(string letter) {

    }

    public void SpellOver() {

    }

}
