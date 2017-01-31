using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        print("Nu är vi igång!!");


        keywords.Add("Price", () =>
        {
            // Call the OnReset method on every descendant object.
            print("price added");
            this.BroadcastMessage("OnPrice");
        });

        keywords.Add("six hundred", () =>
        {
            // Call the OnReset method on every descendant object.
            print("600 added");
            this.BroadcastMessage("OnSix");
        });

        //keywords.Add("Journal", () =>
        //{
        //    // Call the OnReset method on every descendant object.
        //    this.BroadcastMessage("OnJournal");

        //    keywords.Add("test", () =>
        //    {
        //        // Call the OnReset method on every descendant object.
        //        this.BroadcastMessage("OnTest");
        //    });

        //});

        //Denna används kanske inte
        keywords.Add("Offert", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnOffert");

        });

        keywords.Add("Patient", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnPatient");
        });

        keywords.Add("Action", () =>
        {
            // Call the OnReset method on every descendant object.
            print("action added");
            this.BroadcastMessage("OnAction");
        });

        keywords.Add("Caries", () =>
        {
            // Call the OnReset method on every descendant object.
            print("caries added");
            this.BroadcastMessage("OnCaries");
        });

        keywords.Add("Mark Wilson", () =>
        {
            // Call the OnReset method on every descendant object.
            print("mark added");
            this.BroadcastMessage("OnMark");
        });


        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
        print("keywordrecognizer started");
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
