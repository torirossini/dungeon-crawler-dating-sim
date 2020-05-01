using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    int SceneToLoad = 1;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}