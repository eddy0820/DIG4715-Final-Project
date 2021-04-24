using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManger : MonoBehaviour 
{
    public bool gameOver = false;

    public bool gameWin = false;
    public GameObject pauseMenu;
    public GameObject enemy;

    public void SwitchScene(string sceneName) 
    {
        SceneManager.LoadScene (sceneName);
    }

    public void SwitchScene() 
    {
        if (gameWin == true) {
            SceneManager.LoadScene ("Win");
        }

        if (gameOver == true) {
            SceneManager.LoadScene ("Lose");
        }
    }

    public void QuitGame()
    {
        Application.Quit ();

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit ();
            Debug.Log ("Game is quitting");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(true);
                enemy.SetActive(false);
            }

        if (Input.GetKeyDown(KeyCode.R))
        {
                pauseMenu.SetActive(false);
                enemy.SetActive(true);
        }
    }

}