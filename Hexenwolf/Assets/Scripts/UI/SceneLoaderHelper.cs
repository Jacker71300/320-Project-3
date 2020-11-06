using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderHelper : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
    
}
