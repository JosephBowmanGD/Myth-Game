using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject player;
    public  GameObject footsteps;

    private void Update()
    {
        if (player.GetComponent<PlayerMovement>().isWalking)
        {
            StartSteps();
        }
        else
        {
            StopSteps();
        }
    }

    void StartSteps()
    {
        footsteps.SetActive(true);
    }

    void StopSteps()
    {
        footsteps.SetActive(false);
    }

}
