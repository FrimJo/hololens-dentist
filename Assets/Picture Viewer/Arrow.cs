using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.InputModule;

public class Arrow : MonoBehaviour, IFocusable, IInputClickHandler {

    public int step = 1;
    
    private MeshRenderer indicator;
    
    // Use this for initialization
    void Start () {
        indicator = transform.Find("Indicator").gameObject.GetComponentInChildren<MeshRenderer>();
        indicator.enabled = false;
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
        SendMessageUpwards("ChangePicture", step);
    }
}