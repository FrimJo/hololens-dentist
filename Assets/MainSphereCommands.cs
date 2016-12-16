using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.Events;
public class MainSphereCommands : MonoBehaviour, IInputClickHandler, IFocusable
{
    Animator anim;
    bool isOpen;
    bool isFocused;
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponentInParent<Animator>();
        this.isOpen = false;
        this.isFocused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isFocused)
        {
            anim.SetBool("menuFocused", true);
        }
    }
    public void OnFocusEnter()
      {
        this.isFocused = true;
      }

      public void OnFocusExit()
      {
        this.isFocused = false;
    }
  
    public void OnInputClicked(InputEventData eventData)
    {
        anim.SetBool("isOpen", true);
        if (anim.GetBool("isOpen"))
        {
            anim.SetBool("isOpen", false);
        }
        else
        {
            anim.SetBool("isOpen", true);
        }

    }
    
}