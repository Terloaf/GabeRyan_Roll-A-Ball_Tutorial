using UnityEngine;
using static LeverTrigger;
using static PlayerController;
using static RestarterLevel2;

public class SlamPowerUp : MonoBehaviour
{
    public GameObject slamPowerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slamPowerUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRestarted == true)
        {
            leverstate = false;
        }
        if(leverstate == true)
        {
            slamPowerUp.SetActive(true);
            
        }

        if(isSlamUnlocked == true)
        {
            slamPowerUp.SetActive(false);
        }

    }
}
