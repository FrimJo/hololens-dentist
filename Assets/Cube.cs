using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.InputModule;

public class Cube : MonoBehaviour, IManipulationHandler, IFocusable
{

    private MeshRenderer meshRenderer;
    [Tooltip("Object color changes to this when selected.")]
    public Color SelectedColor = Color.red;
    public Color FocusedColor = Color.blue;

    private Material material;
    private Color originalColor;

    private Color prevColor;

    // Use this for initialization
    void Start ()
	{
	    meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    // Update is called once per frame
    void Update ()
	{
        /*
	    var headPos = Camera.main.transform.position;
	    var gazeDir = Camera.main.transform.forward;
	    RaycastHit hitInfo;

	    if (Physics.Raycast(headPos, gazeDir, out hitInfo))
	    {
	        meshRenderer.enabled = true;
	    }
	    else
	    {
	        meshRenderer.enabled = false;
	    }
        */
	}

    public void OnFocusEnter()
    {
        material.color = FocusedColor;
    }

    public void OnFocusExit()
    {
        material.color = originalColor;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        material.color = SelectedColor;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        material.color = SelectedColor;
        transform.position += eventData.CumulativeDelta;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        material.color = originalColor;
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        material.color = originalColor;
    }
}
