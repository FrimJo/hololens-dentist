using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveItemsScript : MonoBehaviour, IInputClickHandler
{

    GameObject MainMenuParent;
    // Use this for initialization
    void Start () {
        MainMenuParent = this.transform.parent.gameObject;

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
        DentistItemScript[] ItemControllers = MainMenuParent.GetComponentsInChildren<DentistItemScript>();
        foreach (DentistItemScript ICtrl in ItemControllers)
        {
            ICtrl.ChangeStatus(DentistItemScript.Statuses.Placing);
        }
    }
}
