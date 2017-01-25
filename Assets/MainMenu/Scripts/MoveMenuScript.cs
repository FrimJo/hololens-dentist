using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class MoveMenuScript : MonoBehaviour, IInputClickHandler//, IFocusable
{
    [Tooltip("Menuitem object")]
    public GameObject CollectionToShow;

    [Tooltip("Menu name tag (Unique)")]
    public String TagName;

    [Tooltip("Menu name tag (Unique)")]
    public bool IsVisibleOnStartup = false;

    private bool isVisible;
    private Material material;
    // Use this for initialization
    void Start()
    {
        
        isVisible = false;
        material = GetComponent<Renderer>().material;
        SetTexture();
    }
    private void SetTexture()
    {
        //  material.mainTexture = itemTexture;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsVisibleOnStartup)
        {
            if (isVisible)
            {
                SetMenuAsPlacable();
                IsVisibleOnStartup = false;
            }
            isVisible = IsVisibleOnStartup;
            
        }
    }
    public void OnInputClicked(InputEventData eventData)
    {
        SetMenuAsPlacable();
    }
    private void SetMenuAsPlacable()
    {
        //anim.SetBool("isVisible", true);
        DentistItemScript DIS = (DentistItemScript)(CollectionToShow.GetComponent<DentistItemScript>());
        DIS.ChangeStatus(DentistItemScript.Statuses.Placing);
        print("Clicked on move menu");
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
