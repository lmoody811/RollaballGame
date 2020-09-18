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
    public TextMeshProUGUI highScoreNames;
    public TextMeshProUGUI scoreTitleText;
    public TextMeshProUGUI gameTitleText;
    static public bool gamePlayed;
    private Dictionary<string, int> highScores = new Dictionary<string, int>();
    private string playersName;


    // Start is called before the first frame update
    void Start()
    {

      backBTN.SetActive(false);
      scoreTitleText.text = "";
      highScoreNames.text = "";

      if(PlayerPrefs.HasKey("HighScores") == false) {
        PlayerPrefs.SetString("HighScores", "");
      }

      if(gamePlayed == true) {
        checkForHighScores();
      }
      else {
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
        gameTitleText.text = "";

        scoreTitleText.text = "High Scores";
        backBTN.SetActive(true);

        displayHighScores();
    }

    private void displayHighScores() {
        int i = 1;
        foreach (KeyValuePair<string, int> name in highScores)
          {
            highScoreNames.text += i + ". Name: " + name.Key + " Score: " + name.Value + Environment.NewLine;
            i++;
          }

    }


    public void checkForHighScores() {

      getSavedScores();

      if(highScores.Count == 0 && gamePlayed == true) {
        highScores["Brayan"] = PlayerController.count;
      }
      else if(gamePlayed == true){
          highScores["Lauren"] = PlayerController.count;
          highScores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
          if(highScores.Count == 11) {
              highScores.Remove(highScores.Keys.Last());
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
        Debug.Log(scores);


        int nameIndex;
        int newNameIndex;
        int scoreIndex;
        int newScoreIndex;
        int score;
        string name;
        string stringScore;
        int length;
        string[] savedHighScores = scores.Split(',');


          for(int i = 0; i < savedHighScores.Length; i++) {

            if(savedHighScores[i] != "") {
              nameIndex = savedHighScores[i].IndexOf(' ');
              name = savedHighScores[i].Substring(0, nameIndex);

              stringScore = savedHighScores[i].Split(' ').Last();
              score = int.Parse(stringScore);

              Debug.Log(name);
              Debug.Log(score);

              highScores[name] = score;
            }
          }

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
