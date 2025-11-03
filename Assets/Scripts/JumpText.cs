using TMPro;
using UnityEngine;
using static PlayerController;
public class JumpText : MonoBehaviour
{
    public GameObject jumpTextObject;
    public GameObject camera2;
    private bool jumpTrigger = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpTextObject.SetActive(false);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTextObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    
    {
        camera2.SetActive(true);
        if (other.gameObject.CompareTag("Player"))
        {
            jumpTextObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpTextObject.SetActive(false);
            }

        }
    }
}
