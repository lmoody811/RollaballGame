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


    // Start is called before the first frame update
    void Start()
    {

      backBTN.SetActive(false);
      scoreTitleText.text = "";
      highScoreNames.text = "";


      if(gamePlayed == false) {
        PlayerPrefs.SetInt("DictionaryCount", 0);
      }
      else {
        checkForHighScores();
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

        for(int i = 0; i < highScores.Count; i++) {
            highScoreNames.text += (i+1) + ". " + highScores.ElementAt(i).Key +
            " Points: " + highScores.ElementAt(i).Value + "\r\n";
        }

    }


    public void checkForHighScores() {

      getSavedScores();

      if(highScores.Count == 0 && gamePlayed == true) {
        int index = 0;
        highScores["Brayan"] = PlayerController.count;
        PlayerPrefs.SetInt("Brayan", PlayerController.count);
        PlayerPrefs.SetString("Brayan", index.ToString());
        PlayerPrefs.SetInt("DictionaryCount", 1);
      }
      else {

        foreach (KeyValuePair<string, int> name in highScores.ToList())
          {
            if(PlayerController.count > name.Value) {
              highScores["Lauren"] = PlayerController.count;
            }
          }

        highScores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        if(highScores.Count == 11) {
            highScores.Remove(highScores.Keys.Last());
        }

        saveScores();

      }

    }


    private void saveScores() {

      int t = 1;

      foreach (KeyValuePair<string, int> name in highScores)
        {
          PlayerPrefs.SetInt(name.Key, name.Value);
          PlayerPrefs.SetString(name.Key, t.ToString());

          t++;
        }

      PlayerPrefs.SetInt("DictionaryCount", highScores.Count);

    }

    private void getSavedScores() {
        /*int count = PlayerPrefs.GetInt("DictionaryCount");
        for(int i = 0; i < count; i++) {
          highScores[(PlayerPrefs.GetString(i.ToString()))] = PlayerPrefs.GetInt(PlayerPrefs.GetString(i.ToString()));
        }*/

        int count = PlayerPrefs.GetInt("DictionaryCount");
        Debug.Log(count);
        for(int i = 0; i < count; i ++ ) {
          Debug.Log(PlayerPrefs.GetString("1"));
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
