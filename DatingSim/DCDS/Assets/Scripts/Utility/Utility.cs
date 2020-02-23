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
        //TimeElapsed,
        //DistanceFromFollowTarget,
        CurrentTimePoints,
    }

    //Ints should correspond with the scene numbers
    [System.Serializable]
    public enum Locations
    {
        Overworld = 1,
        Guildhall = 2,
    }

    public enum TimeOfDay
    {
        Morning = 1, Midday = 2, Evening = 3, Night = 4
    }

}
