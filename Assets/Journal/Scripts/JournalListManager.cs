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

    public WindowBehaivour thisWindow;

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
    string name = "";
    private void dataChanged(object data)
    {
        if (data is string)
        {
            name = data.ToString();
            lastChangeCount = -1;
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

        Journal[] journals = patientManager.GetJournals(name);

        foreach (Journal journal in journals)
        {
            GameObject go = (GameObject)Instantiate(PatientEntryPrefab);
            go.transform.SetParent(this.transform, false);
            go.transform.Find("description").GetComponent<Text>().text = journal.Logg;
            go.transform.Find("date").GetComponent<Text>().text = journal.Date.ToString();

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
            Transform t = eventData.selectedObject.transform;
            Text[] texts = t.GetComponentsInChildren<Text>();
            print(texts[0].text);
            windowManager.ShowWindowName("JournalWindow", name);
        }
        catch (Exception e)
        {
            // pallar inte felsöka
        }
    }

    public void CreateNewJournal()
    {
        windowManager.ShowWindowName("JournalWindow", name);
    }
}
