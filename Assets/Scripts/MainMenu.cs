using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject backBTN;
    public GameObject newGameBTN;
    public GameObject highScoresBTN;
    public GameObject quitGameBTN;
    public GameObject developerNames;
    public TextMeshProUGUI highScoreTitles;
    public TextMeshProUGUI highScoreNames;
    public TextMeshProUGUI highScorePoints;
    public TextMeshProUGUI scoreTitleText;
    public TextMeshProUGUI gameTitleText;
    static public bool gamePlayed;
    private Dictionary<string, int> highScores = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {

      backBTN.SetActive(false);
      scoreTitleText.text = "";
      highScoreNames.text = "";
      highScorePoints.text = "";
      highScoreTitles.text = "";

      if(PlayerPrefs.HasKey("HighScores") == false) {
        PlayerPrefs.SetString("HighScores", "");
      }

      if(PlayerController.playerEscaped == false) {
        checkForHighScores();
      }
      else {
        getSavedScores();

      }
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
        developerNames.SetActive(false);
        gameTitleText.text = "";

        scoreTitleText.text = "High Scores";
        highScoreTitles.text = "Name        Score";
        backBTN.SetActive(true);

        displayHighScores();
    }

    private void displayHighScores() {
        int i = 1;
        foreach (KeyValuePair<string, int> name in highScores)
          {
            highScoreNames.text += i  + ". " + name.Key + Environment.NewLine;
            highScorePoints.text += name.Value + Environment.NewLine;
            i++;
          }
    }


    public void checkForHighScores() {

      getSavedScores();

      if(highScores.Count == 0 && gamePlayed == true) {
        highScores[PlayerController.playerName] = PlayerController.count;
      }
      else if(gamePlayed == true){
          highScores[PlayerController.playerName] = PlayerController.count;
          highScores = highScores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
          if(highScores.Count == 11) {
              highScores.Remove(highScores.Keys.First());
      }
    }

      highScores = highScores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
      saveScores();
    }


    private void saveScores() {

      string scoreCount = highScores.Count.ToString();
      string NameAndScore = "";
      string newName = "";

      foreach (KeyValuePair<string, int> name in highScores)
        {
            newName = name.Key + " " + name.Value.ToString() + ",";
            NameAndScore += newName;
        }
        PlayerPrefs.SetString("HighScores", NameAndScore);
        PlayerPrefs.Save();
    }

    private void getSavedScores() {

        string scores = PlayerPrefs.GetString("HighScores");

        int nameIndex;
        int score;
        string name;
        string stringScore;
        string[] savedHighScores = scores.Split(',');


          for(int i = 0; i < savedHighScores.Length; i++) {

            if(savedHighScores[i] != "") {
              nameIndex = savedHighScores[i].IndexOf(' ');
              name = savedHighScores[i].Substring(0, nameIndex);

              stringScore = savedHighScores[i].Split(' ').Last();
              score = int.Parse(stringScore);

              highScores[name] = score;
            }
          }

    }

    public void goBack()
    {
        backBTN.gameObject.SetActive(false);
        scoreTitleText.text = "";

        highScoreNames.text = "";
        highScorePoints.text = "";
        highScoreTitles.text = "";

        gameTitleText.text = "Beach Ball";
        newGameBTN.SetActive(true);
        quitGameBTN.SetActive(true);
        highScoresBTN.SetActive(true);
        developerNames.SetActive(true);
    }
}
