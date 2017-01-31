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
        keywords.Add("Journal", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnJournal");

            keywords.Add("test", () =>
            {
                // Call the OnReset method on every descendant object.
                this.BroadcastMessage("OnTest");
            });

        });

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
                this.BroadcastMessage("OnAction");
            });

            keywords.Add("Price", () =>
            {
                // Call the OnReset method on every descendant object.
                this.BroadcastMessage("OnPrice");
            });
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
