using UnityEngine;
using UnityEngine.SceneManagement;
using static Goal;

public class Restarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MiniGame");


        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();

            
        }
    }
}
