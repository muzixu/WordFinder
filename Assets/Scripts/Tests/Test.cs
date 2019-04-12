using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Test : MonoBehaviour {

    public WordPanel _WordPanelp;
    public WordBar _WordBar;

	void Start () {
        WordBase word1 = new WordBase();
        WordBase word2 = new WordBase();
        word1.WordRaw = "WORD";
        word2.WordRaw = "GOD";

        _WordPanelp.AddWord(word1);
        _WordPanelp.AddWord(word2);

        _WordBar.UpdateWord(word2);
    }
	

	void Update () {
		
	}
}
