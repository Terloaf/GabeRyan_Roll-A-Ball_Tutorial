using UnityEngine;
using static PlayerController;
public class NewEventScript : MonoBehaviour
{
    public GameObject EnemySpheresParent;
    private bool triggerEvent = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemySpheresParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerEvent == true)
        {
            EnemySpheresParent.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Roll Event"));
            triggerEvent = true;

        }
    }

}
