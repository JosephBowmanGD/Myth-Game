using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
    public bool Button1Pressed;
    public bool Button2Pressed;
    public bool Button3Pressed;
    public bool WrongButtonPressed;
    public bool called;

    public GameObject button1;
    public Collider button1collider;

    public GameObject button2;
    public Collider button2collider;

    public GameObject button3;
    public Collider button3collider;

    public GameObject inactivebutton;
    public Collider inactivebuttoncollider;


    void Start()
    {
        button1collider = button1.GetComponent<BoxCollider>();
        button2collider = button2.GetComponent<BoxCollider>();
        button3collider = button3.GetComponent<BoxCollider>();
    }


    void Update()
    {


        if (Button1Pressed == true)
        {
            button1collider.enabled = false;
        }
        if (Button1Pressed == false)
        {
            button1collider.enabled = true;
        }

        if (Button2Pressed == true)
        {
            button2collider.enabled = false;
        }
        if (Button2Pressed == false)
        {
            button2collider.enabled = true;
        }

        if (Button3Pressed == true)
        {
            button3collider.enabled = false;
        }
        if (Button3Pressed == false)
        {
            button3collider.enabled = true;
        }

        if (WrongButtonPressed == true)
        {
            inactivebuttoncollider.enabled = false;
        }
        if (WrongButtonPressed == false)
        {
            inactivebuttoncollider.enabled = true;
        }
    }

    public void ResetPuzzle()
    {
        Button1Pressed = false;
        Button2Pressed = false;
        WrongButtonPressed = false;
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Act Button 1"))
        {
            Button1Pressed = true;
            Debug.Log("Button 1 Pressed success.");
        }

        if (collider.CompareTag("Act Button 2") && Button1Pressed == true)
        {
            Button2Pressed = true;
            Debug.Log("Button 2 Pressed success.");
        }
        if (collider.CompareTag("Act button 3") && Button1Pressed == true && Button2Pressed == true)
        {
            Button3Pressed = true;
            if (!called)
            {
                Debug.Log("Puzzle Complete!");
                called = true;
            }
        }
        if (collider.CompareTag("InAct Button"))
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
}
