using System.Collections;
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
    public bool keepTimer;
    //public bool playerWon;
    private int playerCount;
    public GameObject cube;
    public GameObject specialStarfish;
    public GameObject level;
    private bool showGame;
    public static bool showInputBox;
    public static int winningNumber;
    public static bool wonLevel;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        wonLevel = false;
        timer.text = "Timer: " + countdown + ".0";
        showGame = true;
        MainMenu.gamePlayed = true;
        showInputBox = false;

        declareWinningNumbers();
        StartCoroutine(showLevel());
    }

    // Update is called once per frame
    void Update()
    {
        playerCount = PlayerController.count;

        if (playerCount == winningNumber)
        {
            playerWonLevel();
        }
        else if (keepTimer == true)
        {
            updateTimer();
        }
        else if(keepTimer == false && wonLevel == false && showGame == false)
        {
            playerLoses();
        }
    }

    void startTimer()
    {
        startTime = Time.time;
        keepTimer = true;
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
    private void playerWonLevel()
    {
        string countdownTime = (countdown % 60).ToString("f1");
        timer.text = "Timer: " + countdownTime;
        keepTimer = false;
        wonLevel = true;

    }

    private void playerLoses()
      {
        //timer.text = "Timer: 0.0";
        keepTimer = false;

        cube.SetActive(false);
        specialStarfish.SetActive(false);

        showInputBox = true;
      }

    IEnumerator showLevel()
    {

        yield return new WaitForSeconds(3);

        cube.SetActive(true);
        specialStarfish.SetActive(true);

        level.SetActive(false);

        startTimer();

    }

    private void declareWinningNumbers() {
      if(currentLevel == "1") {
        winningNumber = 12 + PlayerController.count;
      }
      else if(currentLevel == "2") {
        winningNumber = 10 + PlayerController.count;
      }
      else if(currentLevel == "3") {
        winningNumber = 15 + PlayerController.count;
      }
      else if(currentLevel == "4") {
        winningNumber = 15 + PlayerController.count;
      }

    }


}
