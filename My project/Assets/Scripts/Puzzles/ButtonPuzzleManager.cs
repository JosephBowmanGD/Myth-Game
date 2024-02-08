using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
    public bool Button1Pressed;
    public bool Button2Pressed;
    public bool Button3Pressed;
    public bool Button4Pressed;
    public bool Button5Pressed;
    public bool WrongButtonPressed;
    public bool called;
    public GameObject ButtonDown;
    public GameObject ButtonUp;
    public GameObject[] inactiveButtons;
    public GameObject[] activeButtons;
    public bool isSet;

    void Update()
    {
        if (Button1Pressed == true)
        {
            activeButtons[0].GetComponent<BoxCollider>().enabled = false;
            ButtonUp.SetActive(false);
        }
        if (Button1Pressed == false)
        {
            activeButtons[0].GetComponent<BoxCollider>().enabled = true; 
        }
        if (Button2Pressed == true)
        {
            activeButtons[1].GetComponent<BoxCollider>().enabled = false;
            ButtonUp.SetActive(false);
        }
        if (Button2Pressed == false)
        {
            activeButtons[1].GetComponent<BoxCollider>().enabled = true;
        }
        if (Button3Pressed == true)
        {
            activeButtons[2].GetComponent<BoxCollider>().enabled = false;
            ButtonUp.SetActive(false);
        }
        if (Button3Pressed == false)
        {
            activeButtons[2].GetComponent<BoxCollider>().enabled = true;
        }
        if (Button4Pressed == true)
        {
            activeButtons[3].GetComponent<BoxCollider>().enabled = false;
            ButtonUp.SetActive(false);
        }
        if (Button4Pressed == false)
        {
            activeButtons[3].GetComponent<BoxCollider>().enabled = true;
        }
        if (Button5Pressed == true)
        {
            activeButtons[4].GetComponent<BoxCollider>().enabled = false;
            ButtonUp.SetActive(false);
        }
        if (Button5Pressed == false)
        {
            activeButtons[4].GetComponent<BoxCollider>().enabled = true;
        }

        if (WrongButtonPressed == true)
        {
            foreach(GameObject obj in inactiveButtons)
            {
                obj.GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (WrongButtonPressed == false)
        {
            foreach (GameObject obj in inactiveButtons)
            {
                obj.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void ResetPuzzle()
    {
        Button1Pressed = false;
        Button2Pressed = false;
        Button3Pressed = false;
        Button4Pressed = false;
        WrongButtonPressed = false;
        ButtonUp.SetActive(true);
        isSet = true;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Act Button 1"))
        {
            Button1Pressed = true;
            ButtonDown.SetActive(true);
            Invoke(nameof(DisableAudio), 0.3f);
            Debug.Log("Button 1 Pressed success.");
        }
        if (collider.CompareTag("Act Button 2") && Button1Pressed == true)
        {
            Button2Pressed = true;
            ButtonDown.SetActive(true);
            Invoke(nameof(DisableAudio), 0.3f);
            Debug.Log("Button 2 Pressed success.");
        }
        if (collider.CompareTag("Act button 3") && Button1Pressed == true && Button2Pressed == true)
        {
            Button3Pressed = true;
            ButtonDown.SetActive(true);
            Invoke(nameof(DisableAudio), 0.3f);
            Debug.Log("Button 3 pressed success");
        }
        if (collider.CompareTag("Act Button4") && Button1Pressed == true && Button2Pressed == true && Button3Pressed)
        {
            Button4Pressed = true;
            ButtonDown.SetActive(true);
            Invoke(nameof(DisableAudio), 0.3f);
            Debug.Log("Button 4 pressed success");
        }
        if (collider.CompareTag("Act Button 5") && Button1Pressed == true && Button2Pressed == true && Button3Pressed && Button4Pressed)
        {
            Button5Pressed = true;
            Invoke(nameof(DisableAudio), 0.3f);
            ButtonDown.SetActive(true);
            Debug.Log("Puzzle Complete!");
        }
        if (collider.CompareTag("InAct Button") && Button1Pressed)
        {
            WrongButtonPressed = true;
            ResetPuzzle();
            Debug.Log("Reset");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InAct Button"))
        {
            WrongButtonPressed = false;
        }
    }

    void DisableAudio()
    {
        ButtonDown.SetActive(false);
    }
}
