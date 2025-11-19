using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private InputSystemUIInputModule UI;
    public GameObject PlayButton;
    public GameObject ControlButton;
    public GameObject Controls;
    public GameObject BackButton;
    public GameObject ExitButton;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controls.SetActive(false);
        BackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void OnControlButton()
    {
        PlayButton.SetActive(false);
        ControlButton.SetActive(false);
        ExitButton.SetActive(false);
        Controls.SetActive(true);
        BackButton.SetActive(true);
    }

    public void OnBackButton()
    {
        BackButton.SetActive(false);
        Controls.SetActive(false);
        ControlButton.SetActive(true);
        PlayButton.SetActive(true);
        ExitButton.SetActive(true);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
   
}
