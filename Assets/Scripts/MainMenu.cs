using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject backBTN;
    public GameObject newGameBTN;
    public GameObject highScoresBTN;
    public GameObject quitGameBTN;
    public TextMeshProUGUI highScoreNames;
    public TextMeshProUGUI scoreTitleText;
    public TextMeshProUGUI gameTitleText;
    //private TextMeshProUGUI savedHighScoreNames = highScoreNames; use this for later


    // Start is called before the first frame update
    void Start()
    {
        backBTN.SetActive(false);
        scoreTitleText.text = "";
        highScoreNames.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showHighScores()
    {
        newGameBTN.SetActive(false);
        highScoresBTN.SetActive(false);
        quitGameBTN.SetActive(false);
        gameTitleText.text = "";

        scoreTitleText.text = "High Scores";
        backBTN.SetActive(true);

        highScoreNames.text = "1. Lauren";
    }

    public void goBack()
    {
        backBTN.gameObject.SetActive(false);
        scoreTitleText.text = "";

        highScoreNames.text = "";

        gameTitleText.text = "Beach Ball";
        newGameBTN.SetActive(true);
        quitGameBTN.SetActive(true);
        highScoresBTN.SetActive(true);
    }
}
