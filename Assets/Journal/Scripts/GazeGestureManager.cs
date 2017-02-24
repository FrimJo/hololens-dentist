using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    // Use this for initialization
    void Start()
    {

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        // Save the old focus to compare with new
        GameObject oldFocusObject = FocusedObject;

        // Empty FocusObject
        FocusedObject = null;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {

            // Get the new focus
            FocusedObject = hitInfo.collider.gameObject;

            // If focus has switched, run on gaze exit on old target
            if (oldFocusObject != FocusedObject)
            {
                if (oldFocusObject != null) oldFocusObject.BroadcastMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
                if (FocusedObject != null) FocusedObject.BroadcastMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
            }

        }

        // If we didn't hitt a hologram and old focus is not null
        else if (oldFocusObject != null)
        {

            oldFocusObject.BroadcastMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
            oldFocusObject = null;
        }

    }

}