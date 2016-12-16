using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {

    private const int numPictures = 5;
    public Texture[] pictures = new Texture[numPictures];
    private int curPicture = 0;

    private Material material;

    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;
        updatePicture();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    int normalizeIndex(int index)
    {
        return (index + pictures.Length) % pictures.Length;
    }

    void updatePicture()
    {
        material.mainTexture = pictures[curPicture];
    }

    void NextPicture()
    {
        curPicture = normalizeIndex(curPicture + 1);
        updatePicture();
    }

    void PrevPicture()
    {
        curPicture = normalizeIndex(curPicture - 1);
        updatePicture();
    }
}
