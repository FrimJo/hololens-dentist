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
    [Tooltip("Template picture for selected feature")]
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
                    setChildrenVisibility(true);
                    this.GetComponentInChildren<Animator>().SetBool("isVisible", true);
                    //Hide wrapper, show item content
                    break;
                
                case Statuses.ReadyToPlace:
                    setWrapperVisibility(true);
                    //SHow wrapper
                    if (Status.Equals(Statuses.Enabled))
                    {
                        //Hide content
                        this.GetComponentInChildren<Animator>().SetBool("isVisible", false);
                    }
                    break;
                case Statuses.Placing:
                    if (!Status.Equals(Statuses.ReadyToPlace))
                    {
                        setWrapperVisibility(true);
                        //SHow wrapper
                        if (Status.Equals(Statuses.Enabled))
                        {
                            //Hide content
                            this.GetComponentInChildren<Animator>().SetBool("isVisible", false);
                        }
                    }
                    togglePlacableObject();

                    break;
            }
            Status = newStatus;
            print("Wrapper render status: " + this.GetComponent<MeshRenderer>().enabled);
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
    void togglePlacableObject()
    {
        DentistItem_TapToPlace TTP = GetComponent<DentistItem_TapToPlace>();
        TTP.TogglePlacingStatus();
    }

    public void OnInputClicked(InputEventData eventData)
    {
        switch (Status)
        {
            case Statuses.ReadyToPlace:
                ChangeStatus(Statuses.Placing);
                break;
            case Statuses.Placing:
                ChangeStatus(Statuses.Enabled);
                break;
        }
        
    }
}
