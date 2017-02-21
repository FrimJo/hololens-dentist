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

    private bool isMovable;
    private Material material;
    // Use this for initialization
    void Start()
    {

        isMovable = true;
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
            TogglePlacingStatusToItems();
            IsVisibleOnStartup = false;
        }
    }
    public void OnInputClicked(InputEventData eventData)
    {
        
        TogglePlacingStatusToItems();
    }
    private void TogglePlacingStatusToItems()
    {
        GetComponentInChildren<MenuItemColorManager>().ToggleActivated();
        isMovable = !isMovable;
        //anim.SetBool("isVisible", true);
        DentistItemScript DIS = (DentistItemScript)(CollectionToShow.GetComponent<DentistItemScript>());
        if (isMovable)
        {
            DIS.ChangeStatus(DentistItemScript.Statuses.ReadyToPlace);
        }
        else
        {
            DIS.ChangeStatus(DentistItemScript.Statuses.Enabled);
        }
        
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
