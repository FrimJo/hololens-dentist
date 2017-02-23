using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFocusManager : MonoBehaviour {

    //WindowBehaivour currentActive;
    WindowBehaivour[] panels;
    bool hasInit = false;


    // Use this for initialization
    void Start () {

         
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasInit)
        {
            hasInit = true;
            Init();
        }
	}

    private void Init()
    {
        panels = GetComponentsInChildren<WindowBehaivour>();

        for (int i = 0; i < panels.Length; i++)
        {
            if (i == 0)
            {
                panels[i].Show();
                //currentActive = panels[i];
                //currentActive.Focus();
            }
            else
            {
                panels[i].Hide();
            }
        }
    }


    public void SetActivePanel(WindowBehaivour window)
    {
        /*
        if (currentActive)
        {
            currentActive.Unfocus();
        }
        */
        UnFocusAll();
        window.Focus();
        //currentActive = window;
    }

    public void DismissWindow(WindowBehaivour window)
    {
        /*
        if (currentActive.GetInstanceID() == window.GetInstanceID())
        {
            currentActive = null;
        }
        */
        window.Hide();
    }

    public void ShowWindow(WindowBehaivour window)
    {
        window.Show();
        UnFocusAll();
        window.Focus();
        //currentActive = window;
        
    }

    public void ShowWindow(WindowBehaivour window, object data)
    {
        window.Show(data);
        UnFocusAll();
        window.Focus();
        //currentActive = window;
    }

    public void UnFocusAll()
    {
        foreach (WindowBehaivour p in panels)
        {
            p.Unfocus();
        }
    }

    private WindowBehaivour GetWindowWithName(string name)
    {
        foreach (WindowBehaivour p in panels)
        {
            if (p.name.Equals(name))
            {
                return p;
            }
        }
        return null;
    }

    public void ShowWindowName(string name)
    {
        ShowWindow(GetWindowWithName(name));
    }

    internal void ShowWindowName(string name, object data)
    {
        ShowWindow(GetWindowWithName(name), data);
    }
}
