using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuItemColorManager : MonoBehaviour
{
    [Tooltip("Select Primary Color, text color when item not activated")]
    public Color PrimaryColor;
    [Tooltip("Select secondary color, background color when item not activated")]
    public Color SecondaryColor;
    private Text TextObject;
    private SpriteRenderer ImageObject;
    private bool IsActivated;

    // Use this for initialization
    void Start()
    {
        IsActivated = false;
        TextObject = GetComponentInChildren<Text>();
        ImageObject = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Toggle if colors should be inverted
    public void ToggleActivated()
    {
        IsActivated = !IsActivated;
        UpdateColors();
    }
    //Set colors depending in IsActivated
    private void UpdateColors()
    {
        if (IsActivated)
        {
            //SetTextColor(SecondaryColor);
            SetBackgroundColor(PrimaryColor);
        }else
        {
            //SetTextColor(PrimaryColor);
            SetBackgroundColor(SecondaryColor);
        }
    }
    //Set text and image color to selected color
    private void SetTextColor(Color c)
    {
        TextObject.color = c;
        ImageObject.color = c;
    }
    //Set background color to selected color
    private void SetBackgroundColor(Color c)
    {
        Material m = GetComponent<Renderer>().material;
        m.color = c;
    }
}
