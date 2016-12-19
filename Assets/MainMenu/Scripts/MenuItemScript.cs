using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class MenuItemScript : MonoBehaviour, IInputClickHandler, IFocusable
{
    [Tooltip("The colletion to show when menuitem is selected")]
    public GameObject CollectionToShow;
    [Tooltip("Image that represents the collection")]
    public Texture itemTexture;
    private Animator anim;
    private bool isVisible;
    private Material material; 
    // Use this for initialization
    void Start () {
        anim = this.CollectionToShow.GetComponent<Animator>();
        isVisible = false;
        material = GetComponent<Renderer>().material;
        SetTexture();
    }
	private void SetTexture()
    {
        material.mainTexture = itemTexture;
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
        isVisible = !isVisible;


    }

    public void OnFocusEnter()
    {
        throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new NotImplementedException();
    }
}
