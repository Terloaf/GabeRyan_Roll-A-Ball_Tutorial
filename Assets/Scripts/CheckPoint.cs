using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private int checkCount = 1;
    public GameObject player;
    private Transform respawn2;
    private Transform respawn3;
    private Transform respawn1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        }

        if (other.CompareTag("OutOfBounds"))
        {
            if (checkCount == 2)
            {
                player.transform.position = respawn2.transform.position;
            }
        }

          
    }
}
