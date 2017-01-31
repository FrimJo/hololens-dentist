using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class TextInputOffert : MonoBehaviour
{

    private DictationRecognizer dictationRecognizer;
    private InputField currentFocus;

    public GameObject EventSystemObject;
    private EventSystem eventSystem;

    private String currentText;
    private String hypText;
    public String totPrice;
    private Boolean price;

    // Use this for initialization
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

        if (EventSystemObject)
        {
            eventSystem = EventSystemObject.GetComponent<EventSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        setTextOnFocused();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        if(text.Equals("stop"))
        {
            dictationRecognizer.Stop();
            PhraseRecognitionSystem.Restart();
        }
        else if(price)
        {
            int sumVal = Int32.Parse(totPrice);
            int numVal = Int32.Parse(text);
            sumVal += numVal;
            totPrice = Convert.ToString(sumVal);
        }
        else {
            print(text);
            hypText = text;
        }
        
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        print(text);
        currentText = currentText + "\n " + text;
    }

    public void SetSelectedInputField(InputField field)
    {
        currentFocus = field;
        currentText = hypText = "";

        if (field)
        {
            eventSystem.SetSelectedGameObject(currentFocus.GetComponent<GameObject>(), null);
            dictationRecognizer.Start();
        }
        else
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
    {
        if (currentFocus)
        {
            currentFocus.text = currentText + ". " + hypText;
        }
    }
}
