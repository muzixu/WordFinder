using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public WordPanel _WordPanelp;

	void Start () {
        _WordPanelp.AddWord("Hello");
        _WordPanelp.AddWord("nuso");
    }
	

	void Update () {
		
	}
}
