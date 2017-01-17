using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class MenuItemScript : MonoBehaviour, IInputClickHandler//, IFocusable
{
    [Tooltip("The colletion to show when menuitem is selected")]
    public GameObject CollectionToShow;
    [Tooltip("Image that represents the collection")]
    public Texture itemTexture;
    [Tooltip("Menu item name tag (Unique)")]
    public String TagName;
    private Animator anim;
    private Animator parentAnim;
    private bool isVisible;
    private Material material; 
    // Use this for initialization
    void Start () {
        anim = this.CollectionToShow.GetComponent<Animator>();
        parentAnim = this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animator>();
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
        
            
                if (isVisible)
                {
                    //anim.SetBool("isVisible", false);
                    DentistItemScript DIS = (DentistItemScript)(CollectionToShow.GetComponent<DentistItemScript>());
                    DIS.ChangeStatus(DentistItemScript.Statuses.Disabled);
                }
                else
                {
                    //anim.SetBool("isVisible", true);
                    DentistItemScript DIS = (DentistItemScript)(CollectionToShow.GetComponent<DentistItemScript>());
                    DIS.ChangeStatus(DentistItemScript.Statuses.Placing);
                }
                isVisible = !isVisible;
                parentAnim.SetBool("isOpen", false);
        
        
        print("menuItem clicked!");
     

    }

   /* public void OnFocusEnter()
    {
        throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new NotImplementedException();
    }*/
}
