using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    DentistItemScript _parentScript;

    private bool lockedAfterStartUp = false;

    void Start () {

        // Set status to unlocked
        _parentScript = GetComponentInParent<DentistItemScript> ();

	}

    private void Update()
    {
        // If parent has script and has not been locked after startup
        if (_parentScript != null && !lockedAfterStartUp)
        {

            print("placing menu");
            // Set status to placing
            _parentScript.ChangeStatus(DentistItemScript.Statuses.Placing);
            lockedAfterStartUp = true;
        }
    }

}
