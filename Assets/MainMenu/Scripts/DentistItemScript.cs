using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity;

public class DentistItemScript : MonoBehaviour , IInputClickHandler
{
    private Renderer renderer;
    private Statuses Status;
    private bool WrapperVisible;
    public enum Statuses { Disabled, Enabled, Placing, ReadyToPlace };
    [Tooltip("Template picture for selected feature NOT ACTIVE")]
    public Texture itemTexture;
    // Use this for initialization
    void Start () {
    WrapperVisible = false;
    Status = Statuses.Disabled;
    setWrapperVisibility(false);
    SetTexture();
    }
    private void SetTexture()
    {
       
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = itemTexture;
        
    }
    // Update is called once per frame
    void Update () {
        setWrapperVisibility(WrapperVisible);
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
                    SetPlacableObject(false);
                    //Hide wrapper, show item content
                    break;
                //If item is in placable limbo. It can be moved but will not be enabled by placing it.
                case Statuses.ReadyToPlace:
                    //SHow wrapper
                    setWrapperVisibility(true);
                    //Hide content
                    setChildrenVisibility(true);
                    this.GetComponentInChildren<Animator>().SetBool("isVisible", true);

                    break;
                //When item is being placed and will be enabled upon click.
                case Statuses.Placing:
                    SetPlacableObject(true);
                        setWrapperVisibility(true);
                        //SHow wrapper
                        if (Status.Equals(Statuses.Disabled))
                        {
                            //Show Content
                            setChildrenVisibility(true);
                            this.GetComponentInChildren<Animator>().SetBool("isVisible", true);
                        }
                    break;
            }
            Status = newStatus;
            print("Wrapper  status: " + Status);
        }
        
    }
    public Statuses GetStatus()
    {
        return Status;
    }
    void setChildrenVisibility(bool visible)
    {
        // toggles the visibility of this gameobject and all it's children
        var renderers = this.GetComponentsInChildren<MeshRenderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }
    void setWrapperVisibility(bool visible) {
        
            this.GetComponentInChildren<MeshRenderer>().enabled = visible;
            this.GetComponent<BoxCollider>().enabled = visible;
         
        WrapperVisible = visible;

    }
    void SetPlacableObject(bool IsPlacing)
    {
        DentistItem_TapToPlace TTP = GetComponent<DentistItem_TapToPlace>();
        TTP.SetPlacingStatus(IsPlacing);
    }
    void TogglePlacebleObject()
    {
        DentistItem_TapToPlace TTP = GetComponent<DentistItem_TapToPlace>();
        TTP.TogglePlacingStatus();
    }

    public void OnInputClicked(InputEventData eventData)
    {
        switch (Status)
        {
            case Statuses.ReadyToPlace:
                TogglePlacebleObject();
                break;
            case Statuses.Placing:
                ChangeStatus(Statuses.Enabled);
                break;
        }
        
    }
}
