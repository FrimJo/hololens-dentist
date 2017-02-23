using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalWindowManager : MonoBehaviour {
    public Dropdown TypeValue;
    public Dropdown Description;
    public InputField Logg;
    public PatientManager patientManager;
    public WindowFocusManager windowManager;

    WindowBehaivour thisWindow;
    Journal thisJournal;

    // Use this for initialization
    void Start () {
        thisWindow = this.GetComponent<WindowBehaivour>();
        thisWindow.dataChangedEvent += dataChanged;
        Logg.text = "";
        thisJournal = new Journal("David Bergvik");
    }

    private void dataChanged(object source)
    {
        if (source is string)
        {
            thisJournal = new Journal(source as string) { Date = "24/02/2017" };
            TypeValue.value = PatientManager.TYPES.Examination;
            Description.value = PatientManager.DESCRIPTIONS.Adult;

            /*
            Journal j = patientManager.GetJournal(source as string, 0);
            if (j != null)
            {
                Logg.text = j.Logg;
                TypeValue.value = j.Type;
                Description.value = j.Description;
                thisJournal = j;
            } else
            {
                thisJournal = new Journal(source as string) { Date = new DateTime() };
                TypeValue.value = PatientManager.TYPES.Examination;
                Description.value = PatientManager.DESCRIPTIONS.Adult;
            }
            */
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SaveJournal()
    {
        thisJournal.Type = TypeValue.value;
        thisJournal.Description = Description.value;
        thisJournal.Logg = Logg.text;
        thisJournal.Date = "24/02/2017";
        patientManager.InsertOrUpdateJournal(thisJournal);
        windowManager.DismissWindow(thisWindow);
    }
}
