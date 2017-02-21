using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SnapPointScript : MonoBehaviour, IInputClickHandler {

	// Public variables for use in side and ouside the script
	public bool enabled {
		get {
			return _enabled;
		}

		set {

			// Enables or disables the SnapPoint
			_renderer.enabled = enabled;
			_collider.enabled = enabled;
			_enabled = enabled;
		}
	}
		
	// Private variables used in the script
	private bool _enabled;
	private Animator _animator;
	private Renderer _renderer;
	private SphereCollider _collider;
	private DentistItemScript _parentScript;

	void Awake() {
		_animator = GetComponent<Animator> ();
	}

	void Start () {

		// Get the components used in the script

		_renderer = GetComponent<Renderer> ();
		_collider = GetComponent<SphereCollider> ();
		_parentScript = GetComponentInParent<DentistItemScript> ();

		// Disable the SnapPoint as default
		//enabled = false;
	}

	void Update () {}

	// When a user looks at the SnapPoint stop animation
	public void OnGazeEnter()
	{
		// Put animation to starting position and stop
		//_animator.enabled = false;
		_animator.SetBool ("isFocus", true);
	}

	// When a user stop looks at the SnapPoint start animation
	public void OnGazeExit()
	{
		// Start animation
		//_animator.enabled = true;
		_animator.SetBool ("isFocus", false);
	}

	public void OnInputClicked(InputEventData eventData)
	{	
		// If we foud a script on parent and it is not already ReadyToPlace
		if (_parentScript != null && !_parentScript.GetStatus().Equals(DentistItemScript.Statuses.Placing)) {

			// Set it to ReadyToPlace
			_parentScript.ChangeStatus (DentistItemScript.Statuses.Placing);
		}	

	}

}
