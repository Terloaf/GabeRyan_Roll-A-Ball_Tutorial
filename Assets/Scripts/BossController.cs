using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 Velocity = Vector3.zero;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref Velocity, speed);
    }
}
