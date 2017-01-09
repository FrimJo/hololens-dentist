using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DentistItemScript : MonoBehaviour , IInputClickHandler
{
    private Statuses Status;
    public enum Statuses { Disabled, Enabled, Placing };
	// Use this for initialization
	void Start () {
        Status = Statuses.Disabled;
        setWrapperVisibility(false);

    }
	
	// Update is called once per frame
	void Update () {

        }
    public void ChangeStatus(Statuses newStatus)
    {
        if (!newStatus.Equals(Status))
        {
           
            switch (newStatus)
            {
                case Statuses.Disabled:
                    setWrapperVisibility(false);
                    setChildrenVisibility(false);
                    this.GetComponentInChildren<Animator>().SetBool("isVisible", false);
                    //Hide wrapper (and its children)
                    break;
                case Statuses.Enabled:
                    setWrapperVisibility(false);
                    setChildrenVisibility(true);
                    this.GetComponentInChildren<Animator>().SetBool("isVisible", true);
                    //Hide wrapper, show item content
                    break;
                case Statuses.Placing:
                    setWrapperVisibility(true);
                    //SHow wrapper
                    if (Status.Equals(Statuses.Enabled)){
                        //Hide content
                        this.GetComponentInChildren<Animator>().SetBool("isVisible", false);
                    }
                    break;
            }
            Status = newStatus;
        }
        
    }
    void setChildrenVisibility(bool visible)
    {
        // toggles the visibility of this gameobject and all it's children
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }
    void setWrapperVisibility(bool visible) {
        this.GetComponent<Renderer>().enabled = visible;
        }

    public void OnInputClicked(InputEventData eventData)
    {
        ChangeStatus(Statuses.Enabled);
    }
}
