using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    [System.Serializable]
    public enum CurrentView
    {
        Forward = 0,
        Right = 1,
        Left = 2,
    }

    [System.Serializable]
    public enum Condition
    {
        TimeElapsed,
        DistanceFromFollowTarget,
        CurrentTimePoints,
    }

}
