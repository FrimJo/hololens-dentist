using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpatialPanelManager : MonoBehaviour, IInputClickHandler {

    //private PanelColorManager panelColorManager;
    public WindowFocusManager windowFocusManager;
    public GameObject SpatialPanelPrefab;
    public String PanelTagName = "NoNamePanel";
    public int thickness = 50;

    private Color highlightColor;
    private Color inactiveColor;

    //GameObject panel;

    internal String GetTagName()
    {
        return PanelTagName;


    }


    // Use this for initialization
    void Start () {
        highlightColor = new Color(60 / 255.0f, 102 / 255.0f, 255 / 255.0f, 1);
        inactiveColor = new Color(45 / 255.0f, 76 / 255.0f, 188 / 255.0f, 1);

        /*
        GameObject go = (GameObject)Instantiate(SpatialPanelPrefab);
        
        RectTransform canvasRect = this.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;
        Vector3 canvasPos = this.transform.localPosition;

        Vector3 scale = new Vector3(canvasSize.x, canvasSize.y, thickness);
        go.transform.localScale = scale;

        float zPos = canvasPos.z + (thickness / 2) + 1;

        go.transform.position = new Vector3(canvasPos.x, canvasPos.y, zPos);
        go.transform.SetParent(this.transform.parent, false);


        panelColorManager = go.GetComponent<PanelColorManager>();
        panel = go;
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FocusOnPanel()
    {
        this.transform.GetComponentInChildren<Image>().color = highlightColor;
        //panelColorManager.Enable();
        //UpdatePosition();
    }
    /*
    private void UpdatePosition()
    {
        RectTransform canvasRect = this.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;
        Vector3 canvasPos = this.transform.localPosition;

        Vector3 scale = new Vector3(canvasSize.x, canvasSize.y, thickness);
        panel.transform.localScale = scale;

        float zPos = canvasPos.z + (thickness / 2) + 1;

        panel.transform.position = new Vector3(canvasPos.x, canvasPos.y, zPos);
    }
    */
    public void UnFocusPanel()
    {
        this.transform.GetComponentInChildren<Image>().color = inactiveColor;
        //panelColorManager.Disable();
    }

    public void OnInputClicked(InputEventData eventData)
    {
        windowFocusManager.SetActivePanel(this.transform.parent.GetComponent<WindowBehaivour>());
    }
}
