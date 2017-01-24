using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPointManager : MonoBehaviour {

	// Public variables for use in side and ouside the script
	public bool enabled {
		get {
			return _enabled;
		}

		set {

			// Enableds or disables the SnapPoint
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
		enabled = false;
	}

	void Update () {}

	// When a user looks at the SnapPoint stop animation
	public void OnGazeEnter()
	{
		_animator.enabled = false;
	}

	// When a user stop looks at the SnapPoint start animation
	public void OnGazeExit()
	{
		_animator.enabled = true;
	}

}
