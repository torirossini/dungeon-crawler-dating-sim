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
    FMOD.Studio.EventInstance greetingEvent;
    FMOD.Studio.EventInstance exclamationEvent;
    FMOD.Studio.EventInstance goodbyeEvent;

    private void Start()
    {
        // assign the emitters based on the events attached to the found emitters
        foreach(StudioEventEmitter e in GetComponents<StudioEventEmitter>())
        {
            if(e.Event == greetingEventName)
            {
                greetingEvent = e.EventInstance;
            }
            else if (e.Event == exclamationEventName)
            {
                exclamationEvent = e.EventInstance;
            }
            else if (e.Event == goodbyeEventName)
            {
                goodbyeEvent = e.EventInstance;
            }
        }
    }

    // helper function to set and call an FMOD event
    public void Bark(string name, float value)
    {
        if (name == greetingEventName)
        {
            greetingEvent.setParameterByName("C1Greeting", value);
            RuntimeManager.PlayOneShot(greetingEventName);
        }
        else if (name == exclamationEventName)
        {
            exclamationEvent.setParameterByName("C1Exclamation", value);
            RuntimeManager.PlayOneShot(exclamationEventName);
        }
        else if (name == goodbyeEventName)
        {
            goodbyeEvent.setParameterByName("C1Goodbye", value);
            RuntimeManager.PlayOneShot(goodbyeEventName);
        }
    }
}
