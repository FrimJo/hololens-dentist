using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	void Start () {

		// Set status to unlocked
		DentistItemScript _parentScript = GetComponentInParent<DentistItemScript> ();

		// If parent has script
		if (_parentScript) {

			// Set status to placing
			_parentScript.ChangeStatus (DentistItemScript.Statuses.Placing);
		}

	}

}
