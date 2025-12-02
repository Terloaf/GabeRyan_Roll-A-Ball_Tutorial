using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System;
using static CheckPoint;
using UnityEngine.SceneManagement;
using static Goal;
using static RestarterLevel2;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject BridgeObject;
    public Animator BridgeFall;
    private float jumpForce = 250;
    private float slamForce = 1000;
    private bool isGrounded;
    private bool slamForceState;
    public static bool isGroundedUnlocked = false;
    public static bool isSlamUnlocked = false;
    public bool enablePlayerMovement = true;
    public GameObject restarter;

    public GameObject powerUpHelp;
    public GameObject powerUpHelp2;

    void Start()
    {
        enablePlayerMovement = true;
        winTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        

        BridgeFall = BridgeObject.GetComponent<Animator>();
        BridgeFall.enabled = false;

        powerUpHelp.SetActive(false);
        powerUpHelp2.SetActive(false);


        
        
    }
    private void Update()
    {

        if(level2State == true)
        {
            isSlamUnlocked = false;
            isGroundedUnlocked = false;
            level2State = false;
            Destroy(restarter.gameObject);
        }

        if (isRestarted == true)
        {
            
            isSlamUnlocked = false;
            isGroundedUnlocked = false;
            level2State = false;
            isRestarted = false;
        }

        if (isGrounded == true && isGroundedUnlocked == true && Input.GetKeyDown(KeyCode.Space))
        {
            if(powerUpHelp == isActiveAndEnabled)
            {
                powerUpHelp.SetActive(false);
            }
            
            slamForceState = false;
            rb.AddForce(Vector3.up * jumpForce);

        }
        else if (isGrounded == false && isSlamUnlocked == true && Input.GetKeyDown(KeyCode.Space))
        {
            slamForceState = true;
            rb.AddForce(Vector3.down * slamForce);
            if(powerUpHelp2 == isActiveAndEnabled)
            {
                powerUpHelp2.SetActive(false);
            }
            
        }
        

    }
    private void FixedUpdate()
    {
        if(enablePlayerMovement == true)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
        

        

    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
    movementX = movementVector.x;
    movementY = movementVector.y;



    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();


        }
        
        if (other.gameObject.CompareTag("JumpPowerUp"))
        {
            other.gameObject.SetActive(false);
            isGroundedUnlocked = true;
            BridgeFall.enabled = true;
            powerUpHelp.SetActive(true);
        }
        if (other.gameObject.CompareTag("SlamPowerUp"))
        {
            other.gameObject.SetActive(false);
            isSlamUnlocked = true;
            powerUpHelp2.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            slamForceState = false;
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Breakable"))
        {
            
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose! Press R to restart or Esc to quit.";
        }

        if (slamForceState == true && collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Breakable"));
            
        }
        if (collision.gameObject.CompareTag("EnemySphere"))
        {
            gameObject.SetActive(false);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose! Press R to restart or Esc to quit.";
            
            
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            slamForceState = false;
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Breakable"))
        {
            
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Breakable"))
        {
            isGrounded = false;
        }
       
        

    }





}


