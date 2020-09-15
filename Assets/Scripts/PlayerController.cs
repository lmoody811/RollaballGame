﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    public static int count;
    private float movementX;
    private float movementY;
    private bool increaseSpeed = false;
    private bool newStar = false;
    private float startTime;
    private float specialCountdown = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
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
