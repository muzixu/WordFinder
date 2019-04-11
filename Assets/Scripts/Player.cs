using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 MousePosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            //从摄像机发出到点击坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(MousePosition);
            RaycastHit hitinfo;

            if (Physics.Raycast(ray, out hitinfo))
            {
                GameObject templetter = hitinfo.collider.gameObject;
                Debug.Log("碰到的物体是" + templetter.name);
                if (templetter.tag == "Letter")
                {
                    templetter.SendMessage("OnTouch");
                    Debug.Log("OnTouch 点到");
                }

            }
        }

        
    }
}
