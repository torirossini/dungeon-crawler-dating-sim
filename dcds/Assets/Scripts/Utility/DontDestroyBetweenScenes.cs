using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// helper script for keeping a GO persistant between scenes
public class DontDestroyBetweenScenes : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("IM ALIVE!");
        // check for multiple instances of obj, Destroy if this already exists, otherwise add it to DonDestroyOnLoad group
        // GO NEEDS TO BE TAGGED FOR THIS TO WORK
        int numInstances = GameObject.FindGameObjectsWithTag(gameObject.tag).Length;
        if (numInstances > 1)
        {
            Debug.Log("Destroying duplicate of " + gameObject.tag);
            //Destroy(gameObject);
        }
        else
        {
            Debug.Log("Adding " + gameObject.tag + " to DontDestroyOnLoad");
            DontDestroyOnLoad(gameObject);
        }
    }
}
