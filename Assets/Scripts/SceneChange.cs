using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]int loadSceneIndex;

    public void SwitchScene()
    {
        SceneManager.LoadSceneAsync(loadSceneIndex);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
