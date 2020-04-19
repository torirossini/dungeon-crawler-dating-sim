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
    public int neutralValue = 0;
    public int angryValue = 1;
    public int sadValue = 2;
    public int happyValue = 3;

    // emitters for the different character interactions from FMOD
    FMOD.Studio.EventInstance greetingEvent;
    FMOD.Studio.EventInstance exclamationEvent;
    FMOD.Studio.EventInstance goodbyeEvent;

    private void Start()
    {
        greetingEvent = RuntimeManager.CreateInstance(greetingEventName);
        exclamationEvent = RuntimeManager.CreateInstance(exclamationEventName);
        goodbyeEvent = RuntimeManager.CreateInstance(goodbyeEventName);
    }

    // helper function to set and call an FMOD event
    public void Bark(string name, int mood)
    {
        if (name == greetingEventName)
        {
            greetingEvent.setParameterByName("CharacterInteraction", mood);
            greetingEvent.start();
        }
        else if (name == exclamationEventName)
        {
            exclamationEvent.setParameterByName("CharacterInteraction", mood);
            exclamationEvent.start();
        }
        else if (name == goodbyeEventName)
        {
            goodbyeEvent.setParameterByName("CharacterInteraction", mood);
            goodbyeEvent.start();
        }
    }
}
