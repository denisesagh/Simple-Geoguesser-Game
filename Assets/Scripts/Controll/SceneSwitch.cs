using System;

using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitch : MonoBehaviour
{
    

    public void loadScene(String sceneToLoad)
    {
        SceneManager.LoadScene(sceneName: sceneToLoad);
    }

    
}
