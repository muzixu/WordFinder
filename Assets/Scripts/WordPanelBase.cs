using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class WordPanelBase : MonoBehaviour {

    public GameObject WordPrefab;


    virtual public void ClearWord(WordBase wordBase) { }

    virtual public void FocusOn(WordBase wordBase) { }
}
