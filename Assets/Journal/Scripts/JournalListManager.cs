using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalListManager : MonoBehaviour
{

    public GameObject PatientEntryPrefab;

    public WindowFocusManager windowManager;

    PatientManager patientManager;

    int lastChangeCount;

    // Use this for initialization
    void Start()
    {

        patientManager = GameObject.FindObjectOfType<PatientManager>();

        if (patientManager == null)
            Debug.LogError("You forgot to add PatientManager to game");

        lastChangeCount = patientManager.GetChangeCount();

        //thisWindow.dataChangedEvent += dataChanged;
    }

    private void dataChanged(object data)
    {
        if (data is string)
        {
            print("journal for name: " + data);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            go.transform.Find("name").GetComponent<Text>().text = name;
            go.transform.Find("count").GetComponent<Text>().text = "size of: " + patientManager.GetJournals(name).Length;

            EventTrigger trigger = go.AddComponent<EventTrigger>();
            //EventTrigger trigger = GetComponentInParent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((eventData) => { OnlistItemClicked(eventData); });
            trigger.triggers.Add(entry);
        }
    }

    private void OnlistItemClicked(BaseEventData eventData)
    {
        try
        {
            string name = eventData.selectedObject.transform.Find("name").GetComponent<Text>().text;
            windowManager.ShowWindowName("Journals", name);

        }
        catch (Exception e)
        {
            // pallar inte felsöka
        }
    }
}
