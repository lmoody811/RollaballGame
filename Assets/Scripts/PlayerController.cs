﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    private Dictionary<int, string> highScores = new Dictionary<int, string>();
    public static int count;
    private float movementX;
    private float movementY;
    private bool increaseSpeed = false;
    private bool newStar = false;
    private float startTime;
    private float specialCountdown = 5.0f;
    public GameObject inputField;
    public GameObject enterBTN;
    public static string playerName;
    public static bool playerEscaped;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        inputField.SetActive(false);
        enterBTN.SetActive(false);
        playerEscaped = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();

    }

    void FixedUpdate ()
    {

        if(Keyboard.current.escapeKey.wasPressedThisFrame) {
          SceneManager.LoadScene("Main Menu");
          playerEscaped = true;
        }
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        if(increaseSpeed == false)
        {
            rb.AddForce(movement * speed);
        }
        else
        {
            rb.AddForce(movement * 18);
            updateTimer();
        }

        if(Timer.showInputBox == true) {
          showInputField();         //need to fix this somehow
        }
    }

    private void showInputField() {
      inputField.SetActive(true);
      enterBTN.SetActive(true);
    }

    public void getName() {
      playerName = inputField.GetComponent<TMP_InputField>().text;

      Debug.Log(playerName);
      SceneManager.LoadScene("Main Menu");


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        else if(other.gameObject.CompareTag("SpecialPickUp"))
        {
            other.gameObject.SetActive(false);
            newStar = true;
            increaseSpeed = true;

        }
    }

    void updateTimer()
    {
        if(newStar == false)
        {
            specialCountdown -= Time.deltaTime;

        }
        else
        {
            specialCountdown = 5.0f;
            specialCountdown -= Time.deltaTime;
            newStar = false;
        }
        if (specialCountdown <= 0)
        {
            increaseSpeed = false;
        }

    }


}
