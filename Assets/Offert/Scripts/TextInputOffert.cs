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
    private String totPrice;
    public Text number;
    public Boolean isPrice;

    // Use this for initialization
    void Start()
    {
        print("textinputf offert start");
        isPrice = false;
        print("isprice setted to false");

    }

    // Update is called once per frame
    void Update()
    {
        setTextOnFocused();
        //print("update textinputoffert");
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        if(text.Equals("stop"))
        {
            print("dictation stop");
            dictationRecognizer.Stop();
            isPrice = false;
            PhraseRecognitionSystem.Restart();
            print("keyword restared");
        }
        else if(isPrice)
        {
            print("dicattion isprice");
            int sumVal = Int32.Parse(totPrice);
            int numVal = Int32.Parse(text);
            sumVal += numVal;
            totPrice = Convert.ToString(sumVal);

            //number = GetComponent<Text>();
            number.GetComponent<Text>().text = totPrice;

            print(text);
            hypText = text;
            isPrice = false;
            print("dictation texted in price");
        }
        else {
            print(text);
            hypText = text;
            print("dictation texted");
        }
        
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        print(text);
        currentText = currentText + "\n " + text;
    }

    public void startDictation()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

        if (EventSystemObject)
        {
            eventSystem = EventSystemObject.GetComponent<EventSystem>();
        }
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
