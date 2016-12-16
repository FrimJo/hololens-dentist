using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class MenuItemScript : MonoBehaviour, IInputClickHandler
{
    [Tooltip("The colletion to show when menuitem is selected")]
    public GameObject CollectionToShow;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputEventData eventData)
    {
        //this.CollectionToShow.GetComponent<Animator>().show();
    }
}
