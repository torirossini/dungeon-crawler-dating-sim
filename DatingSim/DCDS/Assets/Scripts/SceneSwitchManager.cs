using Assets.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Utility;

public class SceneSwitchManager:MonoBehaviour
{
    public void Transition(Locations locationToGo)
    {
        CanvasManager.Instance.DestroyIcons();
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync((int)locationToGo));
        

    }
}
