using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManagerScript : MonoBehaviour {

	public Transform snapPointPrefab;
	public int numberOfSnapPoints;

	// Use this for initialization
	void Start () {

		// Instantiate provided number of snap points
		InstantiateSnapPoints(numberOfSnapPoints);

	}
	
	// Update is called once per frame
	void Update () {}

	private void InstantiateSnapPoints(int nr){

		for (int i = 0; i < nr; i++){
			//Transform snapPoint = Instantiate(snapPointPrefab, Vector3.zero, Quaternion.identity);
			//snapPoint.parent = this;
		}

	}

}
