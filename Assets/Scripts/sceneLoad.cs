using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLoad : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadMain1()
    {
        SceneManager.LoadScene("Main1");
    }
    public void LoadMain2()
    {
        SceneManager.LoadScene("Main2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
