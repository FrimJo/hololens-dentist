using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;
    public InputField patientField;
    public InputField actionField;
    public InputField priceField;

    public GameObject ContainerCanvas;
    private TextInputOffert formBehaviour;

    public GameObject EventSystemObject;
    private EventSystem eventSystem;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
       // originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnOffert()
    {
       
    }

    void OnPatient()
    {
        textToSpeech(patientField);
    }

    void OnAction()
    {
        textToSpeech(actionField);
    }

    void OnPrice()
    {
        textToSpeech(priceField);
    }

    // Called by SpeechManager when the user says the "Reset world" command
    void OnJournal()
    {
       
    }

    private void textToSpeech(InputField theField)
    {
        PhraseRecognitionSystem.Shutdown();
        formBehaviour.SetSelectedInputField(theField);
    }

}