using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class MenuFormBehaviour : MonoBehaviour {

    private DictationRecognizer dictationRecognizer;
    //private InputField currentFocus;

    public GameObject EventSystemObject;
    private EventSystem eventSystem;

    private String currentText = "";
    private String hypText = "";

    // Use this for initialization
    void Start () {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

        //eventSystem = EventSystem.current;

        
        if (EventSystemObject)
        {
            //eventSystem = EventSystemObject.GetComponent<EventSystem>();
            eventSystem = EventSystem.current;
        }
        
    }

    // Update is called once per frame
    void Update () {
        setTextOnFocused();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        print(text);
        hypText = text;
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        print(text);
        if (confidence == ConfidenceLevel.High)
        {
            if (text.Equals("next"))
            {
                Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();
                if (!next)
                {
                    eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                }
                SetSelectedGameObject(next.gameObject);
            }
            else if (text.Equals("stop"))
            {
                SetSelectedGameObject(null);
            }
            else
            {
                currentText = currentText + ". " + text;
            }
        }
    }

    public void SetSelectedGameObject(GameObject o)
    {
        currentText = hypText = "";

        if (eventSystem.currentSelectedGameObject.GetInstanceID() != o.GetInstanceID())
        {
            if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            {
                dictationRecognizer.Start();
            }
        }

        eventSystem.SetSelectedGameObject(o);

        if (!o)
        {
            dictationRecognizer.Stop();
            /*
            dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
            dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
            dictationRecognizer.Dispose();
            */
        }
    }
    

    private void setTextOnFocused()
    {/*
        if (eventSystem.currentSelectedGameObject)
        {
            if (eventSystem.currentSelectedGameObject.GetComponent<InputField>())
            {
                InputField field = eventSystem.currentSelectedGameObject.GetComponent<InputField>();
                
                field.text = currentText + ". " + hypText;
            }
        }
        */
    }
}
