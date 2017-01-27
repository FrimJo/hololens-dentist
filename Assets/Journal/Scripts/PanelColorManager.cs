using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelColorManager : MonoBehaviour{

    // Use this for initialization
    public Color ActiveColor;
    public Color InactiveColor;

    private bool isActive = false;

    private bool IsActive
    {
        get { return this.isActive; }
        set
        {
            isActive = value;
            this.GetComponent<MeshRenderer>().material.color = (value ? ActiveColor : InactiveColor);
        }
    }

    // Use this for initialization
    void Start()
    {
        IsActive = isActive;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable()
    {
        IsActive = false;
    }
    public void Enable()
    {
        IsActive = false;
    }

}
