using TMPro;
using UnityEngine;
using static PlayerController;
public class JumpText : MonoBehaviour
{
    public GameObject jumpTextObject;
    private bool jumpTrigger = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpTextObject.SetActive(false);
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
