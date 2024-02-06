using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PyramidPuzzleButtons : MonoBehaviour
{
    
    public bool canPressB;
    public bool canPressM;
    public bool canPressT;
    public GameObject interactPrompt;

    public void Update()
    {
        if(canPressB || canPressM || canPressT)
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
            canPressB = true;
        }
        if (other.CompareTag("PbutM"))
        {
            canPressM = true;
        }
        if (other.CompareTag("PbutT"))
        {
            canPressT = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PbutB"))
        {
            canPressB = false;
        }
        if (other.CompareTag("PbutM"))
        {
            canPressM = false;
        }
        if (other.CompareTag("PbutT"))
        {
            canPressT = false;
        }
    }


}
