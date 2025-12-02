using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using System.Threading;
using static LeverTrigger;
using System.Collections;
using static RestarterLevel2;

public class BossController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 Velocity = Vector3.zero;
    public float speed;
    public Animator animator;
    public bool rightArmSlamActive = false;
    public GameObject bossHurtNewPos;

    public Animator bossAnimator;
    public GameObject bossArmObject;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAnimator = bossArmObject.GetComponent<Animator>();



        
        offset = transform.position - player.transform.position;

        

    }
    
    void Update()
    {

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);


        if (leverstate == true)
        {
            animator.SetBool("IsHurt", true);
            transform.position = Vector3.SmoothDamp(transform.position, bossHurtNewPos.transform.position + offset, ref Velocity, speed);
            StartCoroutine(DmgWait());

            return;
        }

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
    IEnumerator DmgWait()
    {

        yield return new WaitForSeconds(5);
        leverstate = false;
        leverPull.SetBool("LeverResetState", true);
        animator.SetBool("IsHurt", false);
    }



}
    // Update is called once per frame
 

