using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public class Interact : MonoBehaviour
    {
    
    SphereCollider interactRadius;

    void Awake()
    {
        interactRadius = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        interactRadius.radius = 2.5f;
        interactRadius.isTrigger = true;

    }






    



}

