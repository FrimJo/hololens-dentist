using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatientManager : MonoBehaviour {

    Dictionary<string, Dictionary<int, Journal>> patientJournals;

    int changeCount = 0;
    

	// Use this for initialization
	void Start () {
        
		
	}

    void Init()
    {
        if (patientJournals != null)
            return;
        patientJournals = new Dictionary<string, Dictionary<int, Journal>>();
        patientJournals["mattias"] = new Dictionary<int, Journal>();
        patientJournals["mattias"][0] = new Journal() { Description = "This is a test to test jurnals" };
        patientJournals["mattias"][1] = new Journal() { Description = "Second Journal to test with" };
    } 
	
    public Journal GetJournal(string name, int journalNr)
    {
        Init();
        if (patientJournals.ContainsKey(name) == false)
            return null;
        else if (patientJournals[name].ContainsKey(journalNr) == false)
            return null;
        else 
            return patientJournals[name][journalNr];
    }

    public string[] GetPatients()
    {
        Init();
        /*
        string[] patients = new string[patientJournals.Count];
        int index = 0;

        foreach(string name in patientJournals.Keys)
        {
            patients[index] = name;
            index++;
        }
        */

        return patientJournals.Keys.ToArray();
    }

    public Journal[] GetJournals(string name)
    {
        Init();

        if (patientJournals.ContainsKey(name) == false)
            return new Journal[0];

        Journal[] journals = patientJournals[name].Values.ToArray();
        /*
        Journal[] journals = new Journal[patientJournals[name].Count];
        int index = 0;

        foreach(KeyValuePair<int, Journal> dictValue in patientJournals[name])
        {
            journals[index] = dictValue.Value;
            index++;
        }
        */
        return journals;
    }

    public void CreatePatient()
    {
        changeCount++;
    }

    public int GetChangeCount()
    {
        return changeCount;
    }
}
