using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckPoint : MonoBehaviour
{
    public Transform enemyRespawnPosition;
    public GameObject enemySpheresParent;
    public PlayerController playerController;
    private int checkCount = 1;
    public Transform respawn1;
    public Transform respawn2;
    public Transform respawn3;
    private Transform[] Respawner = new Transform[3];
    private int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawner[0] = respawn1;
        Respawner[1] = respawn2;
        Respawner[2] = respawn3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("CheckPoint"))
        {
            other.gameObject.SetActive(false);
            checkCount += 1;
            i += 1;
        }

        

        if (other.CompareTag("OutOfBounds"))
        {
            if (checkCount == 1)
            {
                transform.position = respawn1.position;
                StartCoroutine(TeleportBall());



            }
            if (checkCount == 2)
            {
                transform.position = respawn2.position;
                StartCoroutine(TeleportBall());        

            }

            if (checkCount == 3)
            {
                transform.position = respawn3.position;
                StartCoroutine(TeleportBall());
            }

          

        }
    }

    IEnumerator TeleportBall()
    {
        
        playerController.enablePlayerMovement = false;
        playerController.rb.isKinematic = true;


        // suspend execution for 5 seconds
        yield return new WaitForSeconds(1);

        playerController.rb.isKinematic = false;
        playerController.enablePlayerMovement = true;
    }

}
