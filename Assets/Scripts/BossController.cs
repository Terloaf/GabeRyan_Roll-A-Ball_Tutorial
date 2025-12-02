using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using System.Threading;
using static LeverTrigger;
using System.Collections;

public class BossController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 Velocity = Vector3.zero;
    public float speed;
    public Animator animator;
    public bool rightArmSlamActive = false;
    private Vector3 startPos;
    private Vector3 playerStartpos;
    public int dmgCount = 0;

    public Animator bossAnimator;
    public GameObject bossArmObject;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAnimator = bossArmObject.GetComponent<Animator>();



        startPos = transform.position;
        playerStartpos = player.transform.position;
        offset = transform.position - player.transform.position;

        

    }
    
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);


        if (leverstate == true)
        {
            transform.position = startPos;
            dmgCount += 1;
            bossAnimator.enabled = false;
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
        yield return new WaitForSeconds(10);
        bossAnimator.enabled = true;
        leverstate = false;
        leverPull.SetBool("LeverResetState", true);
    }


}
    // Update is called once per frame
 

