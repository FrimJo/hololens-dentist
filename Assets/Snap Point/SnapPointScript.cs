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

            _enabled = value;

            // Enables or disables the SnapPoint
            _renderer.enabled = _enabled;
			_collider.enabled = _enabled;
            _animator.SetBool("isFocus", !_enabled);

        }
	}
		
	// Private variables used in the script
	private bool _enabled;
	private Animator _animator;
	private Renderer _renderer;
	private SphereCollider _collider;
	private DentistItemScript _parentScript;
    private Transform _snappedTransform;

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

	void Update () {

        // If we have a transform snapped
        if(_snappedTransform != null)
        {
            // Get the position of the camera
            Vector3 cameraPos = Camera.main.transform.position;

            // Rotate this object to face the camera as
            // if the camera were at the same y-position as the object.
            cameraPos.y = transform.position.y;
            this.transform.LookAt(cameraPos);
        }

        
    }

	// When a user looks at the SnapPoint stop animation
	public void OnGazeEnter()
	{
        print("OnGazeEnter");
		// Put animation to starting position and stop
		//_animator.enabled = false;
		_animator.SetBool ("isFocus", true);
	}

	// When a user stop looks at the SnapPoint start animation
	public void OnGazeExit()
	{
        print("OnGazeExit");
        // Start animation
        //_animator.enabled = true;
        _animator.SetBool ("isFocus", false);
    }

	public void OnInputClicked(InputEventData eventData)
	{
        print("SnapPointScript: OnInputClicked");

		// If we foud a script on parent and it is not already ReadyToPlace
		if (_parentScript != null && !_parentScript.GetStatus().Equals(DentistItemScript.Statuses.Placing)) {

            print("SnapPointScript: OnInputClicked: status not placing");

            // Set it to ReadyToPlace
            _parentScript.ChangeStatus (DentistItemScript.Statuses.Placing);
		}	

	}

   

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");

        if (other.tag.Equals("Wrapper"))
        {
            _animator.SetBool("isFocus", true);
            _snappedTransform = other.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");

        if (other.tag.Equals("Wrapper")) { 
            _animator.SetBool("isFocus", false);
            _snappedTransform = null;
        }
    }
}
