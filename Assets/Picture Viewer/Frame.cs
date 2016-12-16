using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {

    private const int numPictures = 5;
    public Texture[] pictures = new Texture[numPictures];
    private int curPicture = 0;

    private Material material;

    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;
        ChangePicture(0);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void ChangePicture(int i)
    {
        var j = i % pictures.Length;
        curPicture = ((curPicture + j) + pictures.Length) % pictures.Length;
        material.mainTexture = pictures[curPicture];
    }
}