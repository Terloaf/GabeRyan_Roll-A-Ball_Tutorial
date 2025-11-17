using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private InputSystemUIInputModule UI;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = GetComponent<InputSystemUIInputModule>();
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("MiniGame");
    }
   
}
