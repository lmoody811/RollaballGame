using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI winText;

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
    public GameObject inputTitle;
    public GameObject enterBTN;
    public static string playerName;
    public static bool playerEscaped;
    public string currentLevel;
    public string newGameScene;
    private string bonus;

    // jumping variables
    public Vector3 jump;
    public float jumpForce = 1.5f;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);

        if(currentLevel == "Level1") {
          count = 0;
        }
        else {
          //keep count the same
        }

        SetCountText();
        bonusText.text = "";
        winText.text = "";

        inputField.SetActive(false);
        inputTitle.SetActive(false);
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

    // Detecting when is player grounded
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

       if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // if (Keyboard.current.jKey.wasPressedThisFrame)
       if (Keyboard.current.FindKeyOnCurrentKeyboardLayout("1").isPressed)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout("2").isPressed)
        {
            SceneManager.LoadScene("Level 2");
        }
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout("3").isPressed)
        {
            SceneManager.LoadScene("Level 3");
        }
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout("4").isPressed)
        {
            SceneManager.LoadScene("Level 4");
        }
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
          showInputField();
        }

        if(Timer.wonLevel == true) {
          if(currentLevel != "Level4") {
            addBonusPoints();
            StartCoroutine(waitForNextLevel());
          }
          else {
            playerWonGame();
            enabled = false;
          }
        }

    }

    private void showInputField() {
      inputField.SetActive(true);
      enterBTN.SetActive(true);
      inputTitle.SetActive(true);
    }

    public void getName() {
      playerName = inputField.GetComponent<TMP_InputField>().text;

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

    void addBonusPoints() {
      if(currentLevel == "Level1") {            //adds bonus points for winning a level
        bonus = "5";
      }
      else if(currentLevel == "Level2") {
        bonus = "10";
      }
      else if(currentLevel == "Level3") {
        bonus = "15";
      }

      bonusText.text = "+ " + bonus + " points";
    }

    void playerWonGame() {
      winText.text = "Congrats! You won! Please enter your name.";
      inputField.SetActive(true);
      enterBTN.SetActive(true);

      count += 30;
    }

    IEnumerator waitForNextLevel()
    {
        yield return new WaitForSeconds(4);

        count += int.Parse(bonus);

        SceneManager.LoadScene(newGameScene);

    }

}
