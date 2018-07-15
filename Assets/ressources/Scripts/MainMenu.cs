﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("First try");
    }

    public void FourPlayers()
    {
        SceneManager.LoadScene("4 Players");
    }

    public void TwoPlayers()
    {
        SceneManager.LoadScene("2 Player");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
