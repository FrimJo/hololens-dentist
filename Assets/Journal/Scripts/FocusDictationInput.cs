using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusDictationInput : MonoBehaviour {

    public DictationManager dictationManager;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DictaitonChanged(string text)
    {
        print(text);
        GetComponent<InputField>().text = text;
    }

    public void onGaze()
    {
        if (dictationManager)
        {
            dictationManager.SetDictationListener(this, new DictaionEventHandler(DictaitonChanged));
            GetComponent<InputField>().text = "David Bergvik";
        }
    }
}
