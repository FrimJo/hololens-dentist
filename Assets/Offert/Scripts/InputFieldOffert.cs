using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldOffert : MonoBehaviour
{

    public GameObject ContainerCanvas;
    private TextInputOffert formBehaviour;

    public GameObject EventSystemObject;
    private EventSystem eventSystem;

    // Use this for initialization
    void Start()
    {
        //if (EventSystemObject)
        //{
        //    eventSystem = EventSystemObject.GetComponent<EventSystem>();
        //    if (eventSystem)
        //    {
        //        EventTrigger trigger = this.GetComponent<EventTrigger>();
        //        EventTrigger.Entry entry = new EventTrigger.Entry();
        //        entry.eventID = EventTriggerType.PointerClick;
        //        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        //        trigger.triggers.Add(entry);
        //    }
        //}

        if (ContainerCanvas)
        {
            formBehaviour = ContainerCanvas.GetComponent<TextInputOffert>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnPointerDownDelegate(PointerEventData data)
    {
        if (formBehaviour)
        {
            formBehaviour.SetSelectedInputField(this.GetComponent<InputField>());
        }
    }
}
