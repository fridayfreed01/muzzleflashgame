using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Muzzle Flash");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Intro Screen");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
