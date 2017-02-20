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

    public Text number;

    public GameObject ContainerCanvas;
    private TextInputOffert textInput;

    public GameObject EventSystemObject;
    private EventSystem eventSystem;

    // Use this for initialization
    void Start()
    {
        print("Sphere command start");
        // Grab the original local position of the sphere when the app starts.
       // originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture

    void OnPatient()
    {
        print("onpatient");
        //textToSpeech(patientField);
        patientField.placeholder.color = Color.red;

    }

    void OnMark()
    {
        print("onmark");
        patientField.text = "David Bergvik";
    }

    void OnAction()
    {
        print("onaction");
       // actionField.selectionColor = Color.red;
        // textToSpeech(actionField);
        // actionField.text = "Karies";
        actionField.placeholder.color = Color.red;
    }

    void OnCaries()
    {
        print("oncaries");
        actionField.text = "Crown";
    }

    void OnPrice()
    {
        print("onprice");
        //priceField.selectionColor = Color.red;
        priceField.placeholder.color = Color.red;
        //textInput.isPrice = true;
        //print("textInput.price = true");
        //textToSpeech(priceField);
    }

    void OnSix()
    {
        print("onfour");
        priceField.text = "7000";
        number.text = "7000";
        
    }

    private void textToSpeech(InputField theField)
    {
        print("text to speech");
        PhraseRecognitionSystem.Shutdown();
        print("text to speech / shutdown");
        textInput.startDictation();
        print("text to speech / start dicattion");
        textInput.SetSelectedInputField(theField);
        print("text to speech / set selected field");
    }

}