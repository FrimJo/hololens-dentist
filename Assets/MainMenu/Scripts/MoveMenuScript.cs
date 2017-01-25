using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMenuScript : MonoBehaviour, IInputClickHandler
{

    public GameObject MainMenuObject;
    private bool IsMovable;
    // Use this for initialization
    void Start()
    {
        IsMovable = false;
    }
    // Update is called once per frame
    void Update()
    {
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
