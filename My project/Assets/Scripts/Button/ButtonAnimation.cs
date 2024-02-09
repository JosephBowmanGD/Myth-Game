using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] private Animator buttonAnimator;
    public ButtonPuzzleManager PuzzleManager;

    public bool is1;
    public bool is2;
    public bool is3;
    public bool is4;
    public bool is5;
    public bool is6;
    public bool is7;
    public bool is8;
    public bool is9;
    public bool is10;
    public bool is11;
    public bool is12;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(PuzzleManager.isComplete == false)
        {
            if (other.CompareTag("Player"))
            {
                if(is1)
                    buttonAnimator.Play("Down1");
                else if (is2)
                    buttonAnimator.Play("Down2");
                else if(is3)
                    buttonAnimator.Play("Down3");
                else if(is4)
                    buttonAnimator.Play("Down4");
                else if(is5)
                    buttonAnimator.Play("Down5");
                else if(is6)
                    buttonAnimator.Play("Down6");
                else if(is7)
                    buttonAnimator.Play("Down7");
                else if(is8)
                    buttonAnimator.Play("Down8");
                else if(is9)
                    buttonAnimator.Play("Down9");
                else if(is10)
                    buttonAnimator.Play("Down10");
                else if(is11)
                    buttonAnimator.Play("Down11");
                else if(is12)
                    buttonAnimator.Play("Down12");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (PuzzleManager.isComplete == false)
        {
            if (other.CompareTag("Player"))
            {
                buttonAnimator.SetBool("Reset", true);
            }
        }
    }

}
