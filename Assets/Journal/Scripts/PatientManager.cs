using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatientManager : MonoBehaviour {

    public abstract class TYPES
    {
        public const int Examination = 1;
        public const int Prosthetics = 2;
    }

    public abstract class DESCRIPTIONS
    {
        public const int Preschoolers = 1;
        public const int Children = 2;
        public const int Adult = 3;
        public const int Epicrisis = 4;
        public const int Investigation = 5;
        public const int InvestigationHospitalDentistry = 6;
        public const int InvestigationProsthetics = 7;

        public static string GetString(int i)
        {
            switch(i)
            {
                case 1:
                    return "Preschoolers";
                case 2:
                    return "Children";
                case 3:
                    return "Adult";
                case 4:
                    return "Epicrisis";
                case 5:
                    return "Investigation";
                case 6:
                    return "Investigation Hospital Dentistry";
                case 7:
                    return "Investigation Prosthetics";
            }
            return "";
        }
    }

    Dictionary<string, List<Journal>> patientJournals;

    int changeCount = 0;
    

	// Use this for initialization
	void Start () {
        
		
	}

    void Init()
    {
        if (patientJournals != null)
            return;
        patientJournals = new Dictionary<string, List<Journal>>();
        patientJournals["Mattias Edin"] = new List<Journal>(5);
        patientJournals["Mattias Edin"].Add( new Journal("mattias") { Logg = "This is a test to test jurnals", Date = "4/01/2017", Type = TYPES.Examination, Description = DESCRIPTIONS.Investigation });
        patientJournals["Mattias Edin"].Add( new Journal("mattias") { Logg = "Second Journal to test with", Date = "21/02/2017", Type = TYPES.Examination, Description = DESCRIPTIONS.InvestigationProsthetics });
    } 
	
    public Journal GetJournal(string name, int journalNr)
    {
        Init();
        if (patientJournals.ContainsKey(name) == false)
            return null;
        else if (patientJournals[name].Count < journalNr)
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

        List<Journal> list = patientJournals[name];
        Journal[] js = new Journal[list.Count];
        foreach (Journal j in list)
        {
            Debug.Log(j);
        }
        return list.ToArray<Journal>();
    }

    public void CreatePatient()
    {
        Init();
        if (changeCount == 0)
        {
            patientJournals["Bob"] = new List<Journal>();
            patientJournals["Bob"].Add(new Journal("Bob") { Logg = "This is a test to test jurnals" });
            patientJournals["Bob"].Add(new Journal("Bob") { Logg = "Second Journal to test with" });
            
        }

        changeCount++;

    }

    public void InsertOrUpdateJournal(Journal toUpdate)
    {
        if (patientJournals.ContainsKey(toUpdate.Name))
        {
            bool isDone = false;
            List<Journal> journals = patientJournals[toUpdate.Name];
            for (int i = 0; i < journals.Count(); i++)
            {
                if (journals[i] == toUpdate)
                {
                    isDone = true;
                    journals[i] = toUpdate;
                    changeCount++;
                    break;
                }
            }
            if (!isDone)
            {
                patientJournals[toUpdate.Name].Add(toUpdate);
                changeCount++;
            }
        } else
        {
            patientJournals[name] = new List<Journal>(5);
            patientJournals[name].Add(toUpdate);
            changeCount++;
        }
    }


    public bool CreatePatient(string name)
    {
        Init();
        if (!patientJournals.ContainsKey(name))
        {
            patientJournals[name] = new List<Journal>(5);
            changeCount++;
            return true;
        }
        return false;
    }

    public int GetChangeCount()
    {
        return changeCount;
    }
}
