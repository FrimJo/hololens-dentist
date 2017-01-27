using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFocusManager : MonoBehaviour {

    SpatialPanelManager currentActive;

    // Use this for initialization
    void Start () {
        foreach (SpatialPanelManager childSPM in GetComponentsInChildren<SpatialPanelManager>())
            if (childSPM.GetTagName().Equals("Patients"))
            {
                childSPM.Enable();
            }else
            {
                childSPM.Disable();
            }
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActivePanel(SpatialPanelManager panel)
    {
        if (currentActive)
        {
            currentActive.Disable();
        }
        panel.Enable();
        currentActive = panel;
    }
    
}
