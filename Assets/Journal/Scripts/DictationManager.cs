using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public delegate void DictaionEventHandler(string text);

public class DictationManager : MonoBehaviour {

    private DictationRecognizer dictationRecognizer;

    private event DictaionEventHandler Changed;

    private object currentListeningObj;

    // Use this for initialization
    void Start() {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetDictationListener(object sender, DictaionEventHandler e) 
    {
        print("registering listener");
        Changed = e;
        currentListeningObj = sender;
        if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            dictationRecognizer.Start();
    }

    public void UnregisterListener(object sender)
    {
        print("unregistering listener");
        if (currentListeningObj == sender)
        {
            dictationRecognizer.Stop();
            Changed = null;
            currentListeningObj = null;
        }
    }


    private void DictationRecognizer_DictationHypothesis(string text)
    {
        print(text);
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        print(text);
        if (confidence == ConfidenceLevel.High)
        {
            Changed(text);
        }
    }

}
