using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene;
    public void changeScenes()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void changeScenes(string next)
    {
        SceneManager.LoadScene(next);
    }
}
