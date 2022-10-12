using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class simulation : MonoBehaviour
{
    public string backScene;


    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadBackScene()
    {
        SceneManager.LoadScene(backScene);
    }
}
