using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public static Animator leverPull;
    public GameObject lever;
    public GameObject player;
    public static bool leverstate = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        leverPull = lever.GetComponent<Animator>();
        leverPull.enabled = false;

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            leverPull.enabled = true;
            leverstate = true;

        }
    }
}
