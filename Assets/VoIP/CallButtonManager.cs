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
	private AudioSource _audio;

	void Start () {
		_movie = (MovieTexture) toPlay.GetComponent<RawImage> ().mainTexture;
		_audio = GetComponent<AudioSource>();


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
		
		if (_movie.isPlaying)
		{
			// Stop movie
			_movie.Stop ();
			_audio.Stop();

			// Change color
			GetComponent<Renderer> ().material = playMaterial;

			// Move button inwards
			transform.localPosition -= Vector3.right * 0.0326f;
		}
		else
		{
			// Play movie
			_movie.Play ();
			_audio.Play();

			// Change color
			GetComponent<Renderer> ().material = stopMaterial;

			// Move button outwards
			transform.localPosition += Vector3.right * 0.0326f;
		}
	}
}