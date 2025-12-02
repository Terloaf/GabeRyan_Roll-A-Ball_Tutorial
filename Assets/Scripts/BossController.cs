using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 Velocity = Vector3.zero;
    public float speed;
    public Animator animator;
    public bool rightArmSlamActive = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        offset = transform.position - player.transform.position;

        
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);


        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        

        if (stateInfo.IsName("RightArmSlamCoolDown"))
        {
            rightArmSlamActive = true;

            return;
        }
        else
        {
            rightArmSlamActive = false;
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref Velocity, speed);
        }
            
    }

    
}
    // Update is called once per frame
 

