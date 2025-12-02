using UnityEngine;

public class Level2Win : MonoBehaviour
{
    public GameObject boss;
    public GameObject winText;
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
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(boss.gameObject);
            winText.SetActive(true);


        }
    }
}
