using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.InputModule;

public class Cube : MonoBehaviour, IManipulationHandler, IFocusable, IInputHandler
{

    private MeshRenderer meshRenderer;
    [Tooltip("Object color changes to this when selected.")]
    public Color SelectedColor = Color.red;
    public Color FocusedColor = Color.blue;

    private Material material;
    private Color originalColor;

    private Color prevColor;

	private bool isHeld;
	private Vector3 startPos;

	private IInputSource currentInputSource;
	private uint currentInputSourceId;

    // Use this for initialization
    void Start ()
	{
	    meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
		isHeld = false;
    }

    // Update is called once per frame
    void Update ()
	{
		if (isHeld) {
			Vector3 curHandPos;
			currentInputSource.TryGetPosition(currentInputSourceId, out curHandPos);

			print(curHandPos);
			//transform.position += ((curHandPos - startPos) * 0.01F);
			print(curHandPos - startPos);

			//transform.LookAt(Camera.main.transform);

			//transform.Rotate(Vector3(0f,Vector3.Angle(startPos, curHandPos),0f));
			//transform.forward = Camera.main.transform.InverseTransformVector(Camera.main.transform.forward * -1.0F);
			//transform.forward curHandPos - startPos;
		}
	}

    public void OnFocusEnter()
    {
        material.color = FocusedColor;
    }

    public void OnFocusExit()
    {
        material.color = originalColor;
    }

	public void OnInputDown(InputEventData eventData)
	{
		//if (!eventData.InputSource.GetSupportedInputInfo(eventData.SourceId, SupportedInputInfo.Position))
		if (!eventData.InputSource.SupportsInputInfo(eventData.SourceId, SupportedInputInfo.Position))
			return;

		currentInputSource = eventData.InputSource;
		currentInputSourceId = eventData.SourceId;
		isHeld = true;

		Vector3 gazeHitPos = GazeManager.Instance.HitInfo.point;
		//	Vector3 handPosition;
		currentInputSource.TryGetPosition(currentInputSourceId, out startPos);
		//startPos = Camera.main.transform.InverseTransformDirection(transform - gazeHitPos);
		material.color = SelectedColor;
	}

	public void OnInputUp(InputEventData eventData)
	{
		if (currentInputSource != null &&
		    eventData.SourceId == currentInputSourceId) {
			
			material.color = originalColor;
			isHeld = false;
		}
	}

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        material.color = SelectedColor;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        material.color = SelectedColor;
        transform.position += eventData.CumulativeDelta;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        material.color = originalColor;
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        material.color = originalColor;
    }
}
