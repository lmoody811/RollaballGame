﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewScene : MonoBehaviour
{
    public string newGameScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);      // found in this YouTube video: https://www.youtube.com/watch?v=BjEqZfK15Ws
    }

    public void QuitGame()
    {
        Application.Quit();                        // found in this YouTube video: https://www.youtube.com/watch?v=BjEqZfK15Ws
    }

    public void switchToMenu() {
      SceneManager.LoadScene("Main Menu");
    }
}
