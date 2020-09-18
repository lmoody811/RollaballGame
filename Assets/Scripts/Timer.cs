﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float startTime;
    public float countdown;
    static public bool keepTimer;
    static public bool playerWon;
    private int playerCount;
    public GameObject cube;
    public GameObject specialStarfish;
    public GameObject level;
    public string newGameScene;
    private bool showGame;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "Timer: " + countdown + ".0";
        showGame = true;
        MainMenu.gamePlayed = true;

        StartCoroutine(showLevel());
    }

    // Update is called once per frame
    void Update()
    {
        playerCount = PlayerController.count;

        if (playerCount == 12)
        {
            playerWins();
        }
        else if (keepTimer == true)
        {
            updateTimer();
        }
        else if(keepTimer == false && playerWon == false && showGame == false)
        {
            playerLoses();
        }
    }

    void startTimer()
    {
        startTime = Time.time;
        keepTimer = true;
        playerWon = false;
    }

    void updateTimer()
    {
        float t = Time.time - startTime;

        float playerTime = t % 60;

        countdown -= Time.deltaTime;            //time passed since last frame; found here: https://docs.unity3d.com/ScriptReference/Time-deltaTime.html

        if (countdown > 0)
        {
            string countdownTime = (countdown % 60).ToString("f1");
            timer.text = "Timer: " + countdownTime;
        }
        else
        {
            keepTimer = false;                                // time is up
            showGame = false;
        }

    }
    private void playerWins()
    {
        string countdownTime = (countdown % 60).ToString("f1");
        timer.text = "Timer: " + countdownTime;
        keepTimer = false;
        playerWon = true;


        SceneManager.LoadScene(newGameScene);

    }

    private void playerLoses()
      {
        //timer.text = "Timer: 0.0";
        keepTimer = false;

        cube.SetActive(false);
        specialStarfish.SetActive(false);

      }

    IEnumerator showLevel()
    {

        yield return new WaitForSeconds(3);

        cube.SetActive(true);
        specialStarfish.SetActive(true);

        level.SetActive(false);

        startTimer();

    }



}
