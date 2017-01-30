using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    }

    public void onGaze()
    {
        if (dictationManager)
        {
            dictationManager.SetDictationListener(this, new DictaionEventHandler(DictaitonChanged));
        }
    }
}
