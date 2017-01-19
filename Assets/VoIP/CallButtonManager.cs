using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonManager : MonoBehaviour, IInputClickHandler {

	public Material playMaterial;
	public Material stopMaterial;
	public Vector3 greenPosition;
	public Vector3 redPosition;

	public GameObject toPlay;

	private MovieTexture _movie;

	void Start () {
		_movie = (MovieTexture) this.toPlay.GetComponent<RawImage> ().mainTexture;



		//_movie = (MovieTexture)this.toPlay.GetComponent<Image> ().material.mainTexture;
		//_movie = this.toPlay.GetComponent<Image> ().mainTexture;
	}

	void Update () {
		/*if (!_movie.isPlaying) {
			_thisMaterial = playMaterial;
			_thisTransform.position = greenPosition;
		}*/
	}

	public void OnInputClicked(InputEventData eventData)
	{
		
		if (this._movie.isPlaying)
		{
			// Stop movie
			this._movie.Stop ();

			// Change color
			GetComponent<Renderer> ().material = this.playMaterial;

			// Move button inwards
			transform.localPosition -= Vector3.right * 0.08f;
		}
		else
		{
			// Play movie
			this._movie.Play ();

			// Change color
			GetComponent<Renderer> ().material = this.stopMaterial;

			// Move button outwards
			transform.localPosition += Vector3.right * 0.08f;
		}
	}
}