﻿using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MovieManager : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void OnInputClicked(InputEventData eventData) {
		//( (MovieTexture) GetComponent<Renderer>().material.mainTexture ).Play();
	}
}