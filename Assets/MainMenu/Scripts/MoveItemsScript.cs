using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveItemsScript : MonoBehaviour, IInputClickHandler
{

    public GameObject AllFeaturesParent;
    private bool IsMovable;
    // Use this for initialization
    void Start () {
        IsMovable = false;
    }
	// Update is called once per frame
	void Update () {	
	}

    public void OnInputClicked(InputEventData eventData)
    {
        TogglePlacingStatusToItems();
    }

    private void TogglePlacingStatusToItems()
    {
        IsMovable = !IsMovable;

        print("Trying to set ready to place status on all items");
        DentistItemScript[] ItemControllers = AllFeaturesParent.GetComponentsInChildren<DentistItemScript>();
        foreach (DentistItemScript ICtrl in ItemControllers)
        {
            
            if (!ICtrl.GetStatus().Equals(DentistItemScript.Statuses.Disabled))
            {
                if (IsMovable)
                {
                    print("Found object that will be ready to place");
                    ICtrl.ChangeStatus(DentistItemScript.Statuses.ReadyToPlace);
                }else
                {
                    print("Found object that will be enabled");
                    ICtrl.ChangeStatus(DentistItemScript.Statuses.Enabled);
                }
                    
            }
        }
    }
}
