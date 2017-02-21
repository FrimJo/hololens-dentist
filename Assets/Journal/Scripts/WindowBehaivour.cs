﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDataChangedEvent(object source);

public class WindowBehaivour : MonoBehaviour {

    public SpatialPanelManager panel;

    public event OnDataChangedEvent dataChangedEvent;

    // Use this for initialization
    void Start()
    {
        //panel = this.GetComponentInChildren<SpatialPanelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponentInChildren<SpatialPanelManager>().FocusOnPanel();
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
        this.gameObject.GetComponentInChildren<SpatialPanelManager>().UnFocusPanel();
        this.gameObject.SetActive(false);
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