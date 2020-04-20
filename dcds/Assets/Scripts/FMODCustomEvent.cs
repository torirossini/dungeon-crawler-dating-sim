using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODCustomEvent : MonoBehaviour
{
    // string vars for the name of the event
    [FMODUnity.EventRef]
    public List<string> eventPaths;

    // emitters for the events named above
    FMOD.Studio.EventInstance [] instances;

    // create and attach instances of the events given in the inspector
    private void Start()
    {
        instances = new FMOD.Studio.EventInstance[eventPaths.Count];
        for (int i = 0; i < eventPaths.Count; i++)
        {
            instances[i] = RuntimeManager.CreateInstance(eventPaths[i]);
        }
    }

    // helper function for setting an event's parameter
    public void SetEventParam(string eventPath, string paramName, float value)
    {
        int eventIndex = FindEvent(eventPath);
        if(eventIndex != -1)
        {
            instances[eventIndex].setParameterByName(paramName, value);
        }
    }

    // helper function for playing an event instance
    public void PlayEvent(string eventPath)
    {
        int eventIndex = FindEvent(eventPath);
        if (eventIndex != -1)
        {
            instances[eventIndex].start();
        }
    }

    // helper function for pausing/unpausing an event instance
    public void PauseEvent(string eventPath, bool pause)
    {
        int eventIndex = FindEvent(eventPath);
        if (eventIndex != -1)
        {
            instances[eventIndex].setPaused(pause);
        }
    }

    //helper function for picking an event instance out of the list on this object
    public int FindEvent(string eventPath)
    {
        for (int i = 0; i < eventPaths.Count; i++)
        {
            if (eventPath == eventPaths[i])
            {
                return i;
            }
        }
        return -1;
    }
}
