using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start ()
	{
	    meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
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
}
