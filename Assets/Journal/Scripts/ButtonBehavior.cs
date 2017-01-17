using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;

    public void OnGazeEnter()
    {
        GetComponent<Button>().OnPointerEnter(null);
        print("testclick 1");
    }

    public void OnGazeLeave()
    {
        GetComponent<Button>().OnPointerExit(null);
        print("testclick 2");
    }

    public void OnSelect()
    {
        print("testclick");
    }
}
