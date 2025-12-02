using UnityEngine;

public class JumpPowerUpSpawn : MonoBehaviour
{
    public Animator rightArmAnimator;
    public GameObject powerUp;
    public bool isStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = rightArmAnimator.GetCurrentAnimatorStateInfo(0);
        if (isStarted == false)
        {
            if (stateInfo.IsName("RightArmSlamCoolDown"))
            {
                isStarted = true;
                powerUp.gameObject.SetActive(true);

            }
        }
        

        
    }
}
