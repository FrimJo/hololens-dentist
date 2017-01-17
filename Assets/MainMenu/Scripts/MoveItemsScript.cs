using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveItemsScript : MonoBehaviour, IInputClickHandler
{

    public GameObject AllFeaturesParent;
    // Use this for initialization
    void Start () {
       

    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputEventData eventData)
    {
        setPlacingStatusToItems();
    }

    private void setPlacingStatusToItems()
    {
        print("Trying to set ready to place status on all items");
        DentistItemScript[] ItemControllers = AllFeaturesParent.GetComponentsInChildren<DentistItemScript>();
        foreach (DentistItemScript ICtrl in ItemControllers)
        {
            print(ICtrl.GetStatus());
            if (!ICtrl.GetStatus().Equals(DentistItemScript.Statuses.Disabled))
            {
                print("Found object that will be ready to place");
                ICtrl.ChangeStatus(DentistItemScript.Statuses.ReadyToPlace);
            }
        }
    }
}
