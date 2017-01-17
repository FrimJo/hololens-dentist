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
    public enum Statuses { Disabled, Enabled, Placing };
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
            print("Wrapper render status: " + this.GetComponent<MeshRenderer>().enabled);
        }
        
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
         
        if (WrapperVisible != visible)
        {
            DentistItem_TapToPlace TTP = GetComponent<DentistItem_TapToPlace>();
            TTP.TogglePlacingStatus();
        }
        WrapperVisible = visible;

    }

    public void OnInputClicked(InputEventData eventData)
    {
        ChangeStatus(Statuses.Enabled);
    }
}
