using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject)
            {
                child.gameObject.SetActive(true);

            }
        }
    }

}
