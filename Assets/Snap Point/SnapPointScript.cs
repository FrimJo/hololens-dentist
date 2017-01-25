using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPointScript : MonoBehaviour {

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

	void Start () {

		// Get the components used in the script
		_animator = GetComponent<Animator> ();
		_renderer = GetComponent<Renderer> ();
		_collider = GetComponent<SphereCollider> ();

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

}
