using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FistCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject winTextObject;
    private bool loseState = false;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && loseState == true)
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("RightArmSlamMotion"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.SetActive(false);
                loseState = true;
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose! Press Space to retry.";

            }
        }
        
    }
    //Checks if player is in contact with object EVEN if player is not moving
    private void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("RightArmSlamMotion"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.SetActive(false);
                loseState = true;
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose! Press Space to retry.";
            }
        }
        
       
    }
}
