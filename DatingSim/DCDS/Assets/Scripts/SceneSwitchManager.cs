using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitchManager
{
    public enum GameScene
    {
        Manager,
        Loading,
        Overworld,

    }

    private static Action onLoaderCallback;

    public static void LoadScene(Scene sceneToLoad)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(GameScene.Loading.ToString());
        };

        SceneManager.LoadScene(sceneToLoad.name);
        SceneManager.LoadScene(sceneToLoad.name);
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
