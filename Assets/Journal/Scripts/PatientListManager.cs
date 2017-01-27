using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientListManager : MonoBehaviour {

    public GameObject PatientEntryPrefab;

    PatientManager patientManager;

    int lastChangeCount;

    // Use this for initialization
    void Start () {

        patientManager = GameObject.FindObjectOfType<PatientManager>();

        if (patientManager == null)
            Debug.LogError("You forgot to add PatientManager to game");

        lastChangeCount = patientManager.GetChangeCount();
	}
	
	// Update is called once per frame
	void Update () {
        if (patientManager == null)
            Debug.LogError("You forgot to add PatientManager to game");

        if (lastChangeCount == patientManager.GetChangeCount())
            return;

        lastChangeCount = patientManager.GetChangeCount();

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null); // Become Batman
            Destroy(c.gameObject);
        }

        string[] names = patientManager.GetPatients();

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(PatientEntryPrefab);
            go.transform.SetParent(this.transform, false);
            //go.transform.parent = this.transform;

           // go.GetComponent<Transform>().parent = this.GetComponent<Transform>();

            go.transform.Find("name").GetComponent<Text>().text = name;
            go.transform.Find("count").GetComponent<Text>().text = "size of: " + patientManager.GetJournals(name).Length;
        }
    }
}
