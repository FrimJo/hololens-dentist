using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class MenuItemScript : MonoBehaviour, IInputClickHandler
{
    [Tooltip("The colletion to show when menuitem is selected")]
    public GameObject CollectionToShow;
    private Animator anim;
    private bool isVisible;
    // Use this for initialization
    void Start () {
        this.CollectionToShow.GetComponent<Animator>();
        isVisible = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputEventData eventData)
    {
        print("menuItem clicked!");
        if (isVisible)
        {
            anim.SetBool("isVisible", false);
        }
        else
        {
            anim.SetBool("isVisible", true);
        }
        
    }
}
