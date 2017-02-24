using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonManager : MonoBehaviour, IInputClickHandler {

	public Material playMaterial;
	public Material stopMaterial;
    public Text callingText;

	public GameObject toPlay;

	private MovieTexture _movie;
    private RawImage _rawImage;
	private AudioSource _audio;

	void Start () {
        print("CallButtonmanager: Start()");

        _rawImage = toPlay.GetComponent<RawImage>();
        _movie = (MovieTexture)_rawImage.mainTexture;
		_audio = GetComponent<AudioSource>();
        callingText.gameObject.SetActive(false);

        //StopMovie();

        //_movie = (MovieTexture)this.toPlay.GetComponent<Image> ().material.mainTexture;
        //_movie = this.toPlay.GetComponent<Image> ().mainTexture;
    }

	void Update () {

        if (TimerStarted()) TickTimer();

        if (TimerDone())
        {
            print("CallButtonManager: Update: if TimerDone");
            PlayMovie();
            print("Trippel check2");
            print(mMovieStarted);
            print(_movie.isPlaying);
            StopTimer();
            print("Trippel check3");
            print(mMovieStarted);
            print(_movie.isPlaying);
        }

        // If the movies has been started and has ended (is not playing). Stop movie
        if (MovieStarted() && !MoviePlaying()) {
            print("CallButtonManager: Update: if MovieStarted() && !MoviePlaying()");
            print(MovieStarted());
            print(!MoviePlaying());
            
            StopMovie();
        }

	}

    private float mTimer = 0.0f;
    private bool mIsCounting = false;
    private bool mMovieStarted = false;

    private bool TimerDone() { return TimerStarted() && mTimer <= 0.0f; }

    private void TickTimer() { mTimer -= Time.deltaTime;  }

    private void StartTimer(float time)
    {
        mTimer = time;
        mIsCounting = true;
    }

    private void StopTimer()
    {
        PauseTimer();
        mTimer = 0.0f;
    }

    private void PauseTimer() {  mIsCounting = false; }

    private bool TimerStarted()  { return mIsCounting;  }

    private bool MovieStarted() { return mMovieStarted; }

    private bool MoviePlaying() { return _movie.isPlaying; }


    public void OnInputClicked(InputEventData eventData)
	{
        print("CallButtonManager: OnInputClicked");

        if(!TimerStarted() && !MoviePlaying()) StartMovie();
        else StopMovie();
      
	}

    private void StartMovie()
    {
        print("CallButtonManager: StartMovie");

        // Show the text
        callingText.gameObject.SetActive(true);

        // Start play timer
        StartTimer(3.0f);

        // Change color to red
        GetComponent<Renderer>().material = stopMaterial;

        // Move button inwards
        transform.localPosition += Vector3.right * 0.0326f;
    }

    private void StopMovie()
    {
        print("CallButtonManager: StopMovie");

        // Hide the text
        callingText.gameObject.SetActive(false);

        // Change the color to white of the raw image
        _rawImage.gameObject.SetActive(false);

        // Change color of button to green
        GetComponent<Renderer>().material = playMaterial;

        // Move button outwards
        transform.localPosition -= Vector3.right * 0.0326f;

        // Stop timer if timer started
        if (TimerStarted()) StopTimer();

        // If movie is playing, stop movie
        if (MoviePlaying())
        {
            // Stop movie
            _movie.Stop();
            
            _audio.Stop();
        }

        if (mMovieStarted) mMovieStarted = false;
    }

    private void PlayMovie()
    {
        print("CallButtonManager: PlayMovie");

        print(mIsCounting);
        print(mMovieStarted);
        print(_movie.isReadyToPlay);
        


        // Hide the text
        callingText.gameObject.SetActive(false);

        // Change the color to white of the raw image
        _rawImage.gameObject.SetActive(true);

        // Play movie
        _movie.Play();
        _audio.Play();


        mMovieStarted = true;

        print("Trippel check");
        print(mMovieStarted);
        print(_movie.isPlaying);

    }

    private Color ConvertColor(int r, int g, int b) {
    return new Color(r/255.0f, g/255.0f, b/255.0f);
}
}