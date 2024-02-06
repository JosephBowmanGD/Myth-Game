using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PyramidPuzzleButtons : MonoBehaviour
{
    
    public bool canPressA;
    public bool canPressB;
    public bool canPressC;
    public bool canPressD;
    public GameObject interactPrompt;

    public void Update()
    {
        if(canPressA || canPressB || canPressD || canPressC)
        {
            interactPrompt.SetActive(true);
        }
        else
        {
            interactPrompt.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PbutB"))
        {
            canPressA = true;
        }
        if (other.CompareTag("PbutM"))
        {
            canPressB = true;
        }
        if (other.CompareTag("PbutC"))
        {
            canPressC = true;
        }
        if (other.CompareTag("PbutT"))
        {
            canPressD = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PbutB"))
        {
            canPressA = false;
        }
        if (other.CompareTag("PbutM"))
        {
            canPressB = false;
        }
        if (other.CompareTag("PbutC"))
        {
            canPressC = false;
        }
        if (other.CompareTag("PbutT"))
        {
            canPressD = false;
        }
    }


}
