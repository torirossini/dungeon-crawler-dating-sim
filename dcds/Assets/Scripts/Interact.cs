using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public class Interact : MonoBehaviour
    {
    List<Item> iObjects = new List<Item>();
    Rigidbody pObject;
    List<Item> allObjects = new List<Item>();
    float dist;
    SphereCollider interactRadius;

    void Awake()
    {
        interactRadius = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        interactRadius.radius = 2.5f;
        interactRadius.isTrigger = true;
    }

    void Start()
    {
        
        foreach(Item xObject in allObjects)
        {
            if(xObject.IsActive == true)
            {
                iObjects.Add(xObject);
            }
        }

        foreach(Item interactObject in iObjects)
        {
            ObjectInteract(interactObject.ItemObject);
        }

    }


    void fixedUpdate()
    {
        foreach (Item interactObject in iObjects)
        {
            ObjectInteract(interactObject.ItemObject);
        }
    }


    void ObjectInteract(Rigidbody iObject)
        {
        dist = Vector3.Distance(iObject.position, pObject.position);

        if (dist < 5.0f)
        {
            Console.WriteLine("Interact(E)");
            if (Input.GetKey(KeyCode.E) == true)
            {
                Console.Write("You have interacted with me!");
            }
        }
    }

    

}

