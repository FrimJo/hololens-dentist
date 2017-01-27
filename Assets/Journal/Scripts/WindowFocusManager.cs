using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFocusManager : MonoBehaviour {

    SpatialPanelManager currentActive;

    // Use this for initialization
    void Start () {
        
        SpatialPanelManager[] panels = GetComponentsInChildren<SpatialPanelManager>();

        for(int i = 0; i < panels.Length; i++)
        {
            if (i == 0)
            {
                panels[i].FocusOnPanel();
                currentActive = panels[i];
            }
            else
            {
                panels[i].UnFocusPanel();
            }
        }   
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActivePanel(GameObject go)
    {
        SpatialPanelManager panel = go.GetComponent<SpatialPanelManager>();
        
        if (currentActive)
        {
            currentActive.UnFocusPanel();
        }
        panel.FocusOnPanel();
        currentActive = panel;
    }
    
}
