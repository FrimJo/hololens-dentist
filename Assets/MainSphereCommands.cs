using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSphereCommands : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnSelect()
    {
        anim.SetBool("isOpen", true);
        Debug.Log(anim.GetBool("isOpen"));
    }
}