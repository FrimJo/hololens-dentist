using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class TextInputVoice : MonoBehaviour {


    private Text txtRef;
    private DictationRecognizer dictationRecognizer;
    private String currentText;

    // Use this for initialization
    void Start () {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        txtRef = GetComponent<Text>();

        dictationRecognizer.Start();


    }

    // Update is called once per frame
    void Update () {
        txtRef.text = currentText;
	}

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        //throw new NotImplementedException();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        currentText = text;
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        //throw new NotImplementedException();
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        //throw new NotImplementedException();
    }
}
