using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFocusManager : MonoBehaviour {

    SpatialPanelManager currentActive;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
            child.GetComponent<SpatialPanelManager>().Disable();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActive(SpatialPanelManager panel)
    {
        if (currentActive)
        {
            currentActive.Disable();
        }
        panel.Activate();
    }
    
}
