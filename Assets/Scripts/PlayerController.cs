using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private int count;
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
    private bool isGroundedUnlocked = false;
    private bool isSlamUnlocked = false;

    void Start()
    {
        winTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        

        BridgeFall = BridgeObject.GetComponent<Animator>();
        BridgeFall.enabled = false;
      
    }
    private void Update()
    {
        if (isGrounded == true && isGroundedUnlocked == true && Input.GetKeyDown(KeyCode.Space))
        {
            slamForceState = false;
            rb.AddForce(Vector3.up * jumpForce);

        }
        else if (isGrounded == false && isSlamUnlocked == true && Input.GetKeyDown(KeyCode.Space))
        {
            slamForceState = true;
            rb.AddForce(Vector3.down * slamForce);
            
        }
        

    }
    private void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        

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
            winTextObject.SetActive(true);
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
        }
        if (other.gameObject.CompareTag("SlamPowerUp"))
        {
            other.gameObject.SetActive(false);
            isSlamUnlocked = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            slamForceState = false;
            isGrounded = true;
        }
        

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
        }

        if (slamForceState == true && collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Breakable"));
            
        }
        if (collision.gameObject.CompareTag("EnemySphere"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            slamForceState = false;
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
       
        

    }





}


