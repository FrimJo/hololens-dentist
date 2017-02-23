using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDataChangedEvent(object source);

public class WindowBehaivour : MonoBehaviour {

    public SpatialPanelManager panel;

    public event OnDataChangedEvent dataChangedEvent;

    Vector3 scale;
    

    // Use this for initialization
    void Start()
    {
        //panel = this.GetComponentInChildren<SpatialPanelManager>();
        scale = this.transform.localScale;
        Debug.Log(scale);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        //this.transform.localScale = scale;
        //this.gameObject.SetActive(true);
        panel.FocusOnPanel();

        Animator anm = GetComponent<Animator>();
        if (anm)
        {
            //anm.SetTrigger("Show");
            anm.SetBool("IsVisible", true);
        }
    }

    public void Show(object data)
    {
        Show();
        print("called with data: " + data);
        if (dataChangedEvent != null)
        {
            dataChangedEvent.Invoke(data);
        }
    }

    public void Hide()
    {
        Animator anm = GetComponent<Animator>();
        if (anm)
        {
            //anm.SetTrigger("Hide");
            anm.SetBool("IsVisible", false);
        }
        panel.UnFocusPanel();
        //this.transform.localScale = new Vector3(0, 0, 0);
        //this.gameObject.SetActive(false);
    }

    public void Focus()
    {
        panel.FocusOnPanel();
    }

    public void Unfocus()
    {
        panel.UnFocusPanel();
    }
    
}
