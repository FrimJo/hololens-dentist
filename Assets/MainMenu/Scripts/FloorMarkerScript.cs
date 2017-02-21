using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class FloorMarkerScript : MonoBehaviour, IInputClickHandler {

	private HoloToolkit.Unity.DentistItem_TapToPlace _parentScript;

	// Use this for initialization
	void Start () {
		_parentScript = GetComponentInParent<HoloToolkit.Unity.DentistItem_TapToPlace> ();
	}

	// On click
	public void OnInputClicked(InputEventData eventData)
	{
			
	}
}
