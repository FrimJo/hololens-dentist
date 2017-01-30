using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientPopupBehaviour : MonoBehaviour {

    private InputField input;
    public PatientManager patientManager; 

	// Use this for initialization
	void Start () {
        input = this.GetComponentInChildren<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Accept() {
        if (!input.text.Equals(""))
        {
            patientManager.CreatePatient(input.text);
            this.gameObject.SetActive(false);
        }
    }

    public void Dismiss()
    {
        this.gameObject.SetActive(false);
    }
}
