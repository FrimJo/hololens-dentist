using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMenuScript : MonoBehaviour, IInputClickHandler
{
    [Tooltip("Menuobject that can be moved")]
    public GameObject MainMenuObject;
    [Tooltip("If object should be movable at launch")]
    public bool IsMovableAtLaunch = false;
    private bool IsMovable;
    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (IsMovableAtLaunch)
        {
            TogglePlacingStatusToItems();
            IsMovable = IsMovableAtLaunch;
            IsMovableAtLaunch = false;
        }
        
    }

    public void OnInputClicked(InputEventData eventData)
    {
        TogglePlacingStatusToItems();
    }

    private void TogglePlacingStatusToItems()
    {
        IsMovable = !IsMovable;

        print("Trying to set ready to place status on menu");
        DentistItemScript MenuController = MainMenuObject.GetComponent<DentistItemScript>();
        //Single placement part
        MenuController.ChangeStatus(DentistItemScript.Statuses.Placing);
        //multiple placement part **NOT USED ATM**
        /*
        if (IsMovable)
        {
            print("Menu will be ready to place");
            MenuController.ChangeStatus(DentistItemScript.Statuses.Placing);
        }
        else
        {
            print("Menu will be enabled");
            MenuController.ChangeStatus(DentistItemScript.Statuses.Enabled);
        }
        */
    }
}
