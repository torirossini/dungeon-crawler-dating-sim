using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// helper script for keeping a GO persistant between scenes
public class DontDestroyBetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        // check for multiple instances of obj, Destroy if this already exists, otherwise add it to DonDestroyOnLoad group
        // GO NEEDS TO BE TAGGED FOR THIS TO WORK
        int numInstances = GameObject.FindGameObjectsWithTag(gameObject.tag).Length;
        if (numInstances > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
