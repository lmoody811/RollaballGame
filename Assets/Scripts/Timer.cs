using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject winTextObject;
    public GameObject lostTextObject;
    public TextMeshProUGUI timer;
    private float startTime;
    private float countdown = 60.0f;
    private bool keepTimer;
    private bool playerWon; 
    private int playerCount;
    public GameObject cube;
    public GameObject specialStarfish;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        lostTextObject.SetActive(false);

        startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        playerCount = PlayerController.count;        
        
        if (playerCount == 12)
        {
            playerWins();
        }
        if (keepTimer == true)
        {
            updateTimer();
        }
        if(keepTimer == false && playerWon == false)
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
        }

    }

    void playerLoses()
    {
        timer.text = "Timer: 0.0";
        lostTextObject.SetActive(true);
        keepTimer = false;

        cube.SetActive(false);
        specialStarfish.SetActive(false);
    }

    void playerWins()
    {
        string countdownTime = (countdown % 60).ToString("f1");
        timer.text = "Timer: " + countdownTime;
        winTextObject.SetActive(true);
        keepTimer = false;
        playerWon = true;
    }
}
