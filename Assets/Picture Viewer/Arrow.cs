using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.InputModule;
using System;

public class Arrow : MonoBehaviour, IFocusable, IInputClickHandler {
    public enum Dir { Prev, Next };
    public Dir dir;

    private GameObject frame;

    private MeshRenderer indicator;
    
    // Use this for initialization
    void Start () {
        frame = transform.parent.gameObject;
        indicator = transform.Find("Indicator").gameObject.GetComponentInChildren<MeshRenderer>();
        indicator.enabled = false;
        print(indicator);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnFocusEnter()
    {
        indicator.enabled = true;
    }

    public void OnFocusExit()
    {
        indicator.enabled = false;
    }

    public void OnInputClicked(InputEventData eventData)
    {
        switch(dir)
        {
            case Dir.Prev:
                SendMessageUpwards("PrevPicture");
                break;
            case Dir.Next:
                SendMessageUpwards("NextPicture");
                break;
        }
        
    }

}
