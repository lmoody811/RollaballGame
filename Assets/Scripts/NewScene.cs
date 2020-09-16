using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
<<<<<<<< HEAD:Assets/Scripts/NewScene.cs
=======
>>>>>>> 32c4ae37d10b284dfb0c564f4cc8b86c814ab410
using UnityEngine.SceneManagement;


public class NewScene : MonoBehaviour
{
    public string newGameScene;
<<<<<<< HEAD
========
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


>>>>>>>> 32c4ae37d10b284dfb0c564f4cc8b86c814ab410:Assets/Scripts/MainMenu.cs
    // Start is called before the first frame update
    void Start()
    {
        backBTN.SetActive(false);
        scoreTitleText.text = "";
        highScoreNames.text = "";
=======
    // Start is called before the first frame update
    void Start()
    {
        
>>>>>>> 32c4ae37d10b284dfb0c564f4cc8b86c814ab410
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
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
=======
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);      // found in this YouTube video: https://www.youtube.com/watch?v=BjEqZfK15Ws
    }

    public void QuitGame()
    {
        Application.Quit();                        // found in this YouTube video: https://www.youtube.com/watch?v=BjEqZfK15Ws
>>>>>>> 32c4ae37d10b284dfb0c564f4cc8b86c814ab410
    }
}
