using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarterLevel2 : MonoBehaviour
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
            SceneManager.LoadScene("level 2");


        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();


        }
    }
}
