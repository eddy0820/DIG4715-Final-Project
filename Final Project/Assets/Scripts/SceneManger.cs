﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManger : MonoBehaviour {
    public bool gameOver = false;
    public bool gameWin = false;

    void Start () {
        QuitGame ();

    }
    public void SwitchScene (string sceneName) {
        SceneManager.LoadScene (sceneName);

        if (gameWin == true) {
            SceneManager.LoadScene ("Win");
        }

        if (gameOver == true) {
            SceneManager.LoadScene ("Lose");
        }

    }

    public void QuitGame () {
        if (Input.GetKey (KeyCode.Escape)) {
            //Application.Quit ();
            Debug.Log ("Game is quitting");
        }

    }

}