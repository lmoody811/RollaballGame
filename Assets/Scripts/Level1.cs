﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public string newGameScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.count == 12)
        {
            NewGame();
        }
    }


    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);      // found in this YouTube video: https://www.youtube.com/watch?v=BjEqZfK15Ws
    }
}
