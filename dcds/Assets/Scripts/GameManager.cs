using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private int level = 3;                                  //Current level number, expressed in game as "Day 1".

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        //Call the InitGame function to initialize the first level 
        //InitGame();

    }

    //Initializes the game for each level.
   



    //Update is called every frame.
    void Update()
    {

    }
}

