﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
       public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

       public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }

}