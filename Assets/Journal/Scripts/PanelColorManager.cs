using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelColorManager : MonoBehaviour{

    // Use this for initialization
    public Color ActiveColor;
    public Color InactiveColor;

    private bool _isActive = false;

    private bool IsActive
    {
        get { return this._isActive; }
        set
        {
            _isActive = value;
            this.GetComponent<Renderer>().material.color = (value ? ActiveColor : InactiveColor);
        }
    }

    // Use this for initialization
    void Start()
    {
        IsActive = _isActive;
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
        IsActive = true;
    }

}
