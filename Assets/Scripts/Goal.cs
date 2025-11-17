using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject LevelClearText;
    public TextMeshProUGUI ScoreText;
    public int score = 0;
    private bool LevelClear = false;
    public GameObject Respawner;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelClearText.SetActive(false);
        ScoreText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Player").GetComponent<PlayerController>().count;
        if(LevelClear == true && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (LevelClear == true && Input.GetKey(KeyCode.Space) && score >= 1200)
        {
            SceneManager.LoadScene("Bonus Level");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelClearText.SetActive(true);
            ScoreText.text = "Score: " + (score *= 100);
            LevelClear = true;


            Respawner.SetActive(false);
        }
    }
}
