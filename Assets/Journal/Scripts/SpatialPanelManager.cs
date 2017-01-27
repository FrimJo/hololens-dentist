using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialPanelManager : MonoBehaviour {

    private PanelColorManager panelColorManager;
    public GameObject FocusManager;
    public GameObject SpatialPanelPrefab;
    public int thickness = 50;
    private GameObject SpatialPanel;

    // Use this for initialization
    void Start () {
        GameObject go = (GameObject)Instantiate(SpatialPanelPrefab);
        
        

        RectTransform canvasRect = this.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;
        print(canvasSize);
        Vector3 canvasPos = this.transform.localPosition;

        Vector3 scale = new Vector3(canvasSize.x, canvasSize.y, thickness);
        go.transform.localScale = scale;

        float zPos = canvasPos.z + (thickness / 2) + 1;

        go.transform.position = new Vector3(canvasPos.x, canvasPos.y, zPos);
        go.transform.SetParent(this.transform.parent, false);

        SpatialPanel = go;

        panelColorManager = SpatialPanelPrefab.GetComponent<PanelColorManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Disable()
    {
        panelColorManager.IsActive = false;
    }

    public void Activate()
    {
        panelColorManager.IsActive = true;
    }

    public void OnSelect()
    {
        SpatialPanel.SetActive(SpatialPanel);
    }
}
