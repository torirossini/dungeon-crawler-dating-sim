using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{

    private Scene currentScene;

    public Scene CurrentScene { get => currentScene; set => currentScene = value; }

    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + currentScene.name + "\nActive Scene index: " + currentScene.buildIndex);
    }

    public void LoadScene(int sceneToLoad)
    {
        Debug.Log("Unloading scene " + currentScene.name);
        SceneManager.UnloadScene(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
    }
}
