using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class NPCSoundReactions : MonoBehaviour
{
    // string vars for the names of the sound clips
    public string greetingEventName;
    public string exclamationEventName;
    public string goodbyeEventName;

    // vars to use to set the tone based on npc mood (defaults based on FMOD setup)
    public float angryValue = 0.0f;
    public float sadValue = 0.25f;
    public float neutralValue = 0.5f;
    public float happyValue = 1.0f;

    // emitters for the different 
    StudioEventEmitter greetingEmitter;
    StudioEventEmitter exclamationEmitter;
    StudioEventEmitter goodbyeEmitter;

    private void Start()
    {
        // assign the emitters based on the events attached to the found emitters
        foreach(StudioEventEmitter e in GetComponents<StudioEventEmitter>())
        {
            if(e.Event == greetingEventName)
            {
                greetingEmitter = e;
            }
            else if (e.Event == exclamationEventName)
            {
                exclamationEmitter = e;
            }
            else if (e.Event == goodbyeEventName)
            {
                goodbyeEmitter = e;
            }
        }
    }

    // helper function to set and call an FMOD event
    public void Bark(string name, float value)
    {
        if (name == greetingEventName)
        {
            greetingEmitter.SetParameter("C1Greeting", value);
            greetingEmitter.Play();
        }
        else if (name == exclamationEventName)
        {
            exclamationEmitter.SetParameter("C1Exclamation", value);
            exclamationEmitter.Play();
        }
        else if (name == goodbyeEventName)
        {
            goodbyeEmitter.SetParameter("C1Goodbye", value);
            goodbyeEmitter.Play();
        }
    }
}
