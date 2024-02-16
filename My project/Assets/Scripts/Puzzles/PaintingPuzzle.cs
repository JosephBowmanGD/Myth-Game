using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour
{
    [Header("Paintings Array")]
    public GameObject[] Paintings;

    [Header("Painting Positions")]
    public Transform painting1Pos;
    public Transform painting2Pos;
    public Transform painting3Pos;
    public Transform painting4Pos;
    public Transform painting5Pos;

    [Header("Cloned Paintings")]
    public GameObject clonedPainting1;
    public GameObject clonedPainting2;
    public GameObject clonedPainting3;
    public GameObject clonedPainting4;
    public GameObject clonedPainting5;

    [Header("Index")]
    public int currIndex1;
    public int prevIndex1;
    public int currIndex2;
    public int prevIndex2;
    public int currIndex3;
    public int prevIndex3;
    public int currIndex4;
    public int prevIndex4;
    public int currIndex5;
    public int prevIndex5;

    [Header("Animators")]
    public Animator B1Anim;
    public Animator B2Anim;
    public Animator B3Anim;
    public Animator B4Anim;
    public Animator B5Anim;

    private bool called;
    public bool canPress;

    [Header("Sound")]
    public GameObject SlideSound;

    [Header("E to Interact Text")]
    public GameObject interactText;

    [Header("Button Bools")]
    public bool canPress1;
    public bool canPress2;
    public bool canPress3;
    public bool canPress4;
    public bool canPress5;
    public bool hasIntereactedWith5; //bug fix//
    void Start()
    {
        currIndex1 = 0;
        currIndex2 = 0;
        currIndex3 = 0;
        currIndex4 = 0;
        currIndex5 = 0;

        called = false;
        canPress = true;
        hasIntereactedWith5 = false;

        SlideSound.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !called && canPress1 && canPress)
        {
            ShiftPainting1();
            SlideSound.SetActive(true);
            Invoke(nameof(SoundOff), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.E) && !called && canPress2 && canPress)
        {
            ShiftPainting2();
            SlideSound.SetActive(true);
            Invoke(nameof(SoundOff), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.E) && !called && canPress3 && canPress)
        {
            ShiftPainting3();
            SlideSound.SetActive(true);
            Invoke(nameof(SoundOff), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.E) && !called && canPress4 && canPress)
        {
            ShiftPainting4();
            SlideSound.SetActive(true);
            Invoke(nameof(SoundOff), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.E) && !called && canPress5 && canPress)
        {
            ShiftPainting5();
            hasIntereactedWith5 = true;
            SlideSound.SetActive(true);
            Invoke(nameof(SoundOff), 1.5f);
        }

        if (currIndex1 >= 5)
        {
            currIndex1 = 0;
        }
        if (currIndex2 >= 5)
        {
            currIndex2 = 0;
        }
        if (currIndex3 >= 5)
        {
            currIndex3 = 0;
        }
        if (currIndex4 >= 5)
        {
            currIndex4 = 0;
        }
        if (currIndex5 >= 5)
        {
            currIndex5 = 0;
        }

        prevIndex1 = currIndex1 - 1;
        prevIndex2 = currIndex2 - 1;
        prevIndex3 = currIndex3 - 1;
        prevIndex4 = currIndex4 - 1;
        prevIndex5 = currIndex5 - 1;

        //puzzle completion
        if(currIndex1 == 1 && currIndex2 == 2 && currIndex3 == 3 && currIndex4 == 4 && currIndex5 == 0 && hasIntereactedWith5)
        {
            if (!called)
            {
                PuzzleCompletion();
                called = true;
            }
        }

        if(canPress1 || canPress2 || canPress3 || canPress4 || canPress5)
        {
            interactText.SetActive(true);
        }
        else
        {
            interactText.SetActive(false);
        }

        if (called)
        {
            interactText.SetActive(false);
        }
    }

    public void ShiftPainting1()
    {
        Destroy(clonedPainting1);
        Debug.Log("Destroyed");
        B1Anim.SetBool("Button1Pressed", true);
        Invoke(nameof(ResetAnimations), 0.8f);
        canPress = false;
        Invoke(nameof(PressReset), 0.4f);

        if (prevIndex1 == -1)
        {
            clonedPainting1 = Instantiate(Paintings[0], painting1Pos.position, painting1Pos.rotation);
            currIndex1 += 1;
            Debug.Log("Created Painting 1");
        }
        if (prevIndex1 == 0)
        {
            clonedPainting1 = Instantiate(Paintings[1], painting1Pos.position, painting1Pos.rotation);
            currIndex1 += 1;
            Debug.Log("Created Painting 2");
        }
        if (prevIndex1 == 1)
        {
            clonedPainting1 = Instantiate(Paintings[2], painting1Pos.position, painting1Pos.rotation);
            currIndex1 += 1;
            Debug.Log("Created Painting 3");
        }
        if (prevIndex1 == 2)
        {
            clonedPainting1 = Instantiate(Paintings[3], painting1Pos.position, painting1Pos.rotation);
            currIndex1 += 1;
            Debug.Log("Created Painting 4");
        }
        if (prevIndex1 == 3)
        {
            clonedPainting1 = Instantiate(Paintings[4], painting1Pos.position, painting1Pos.rotation);
            currIndex1 += 1;
            Debug.Log("Created Painting 5");
        }
    }

    public void ShiftPainting2()
    {
        Destroy(clonedPainting2);
        Debug.Log("Destroyed");
        B2Anim.SetBool("Button2Pressed", true);
        Invoke(nameof(ResetAnimations), 0.4f);
        canPress = false;
        Invoke(nameof(PressReset), 0.4f);

        if (prevIndex2 == -1)
        {
            clonedPainting2 = Instantiate(Paintings[0], painting2Pos.position, painting2Pos.rotation);
            currIndex2 += 1;
            Debug.Log("Created Painting 1");
        }
        if (prevIndex2 == 0)
        {
            clonedPainting2 = Instantiate(Paintings[1], painting2Pos.position, painting2Pos.rotation);
            currIndex2 += 1;
            Debug.Log("Created Painting 2");
        }
        if (prevIndex2 == 1)
        {
            clonedPainting2 = Instantiate(Paintings[2], painting2Pos.position, painting2Pos.rotation);
            currIndex2 += 1;
            Debug.Log("Created Painting 3");
        }
        if (prevIndex2 == 2)
        {
            clonedPainting2 = Instantiate(Paintings[3], painting2Pos.position, painting2Pos.rotation);
            currIndex2 += 1;
            Debug.Log("Created Painting 4");
        }
        if (prevIndex2 == 3)
        {
            clonedPainting2 = Instantiate(Paintings[4], painting2Pos.position, painting2Pos.rotation);
            currIndex2 += 1;
            Debug.Log("Created Painting 5");
        }
    }

    public void ShiftPainting3()
    {
        Destroy(clonedPainting3);
        Debug.Log("Destroyed");
        B3Anim.SetBool("Button3Pressed", true);
        Invoke(nameof(ResetAnimations), 0.4f);
        canPress = false;
        Invoke(nameof(PressReset), 0.4f);

        if (prevIndex3 == -1)
        {
            clonedPainting3 = Instantiate(Paintings[0], painting3Pos.position, painting3Pos.rotation);
            currIndex3 += 1;
            Debug.Log("Created Painting 1");
        }
        if (prevIndex3 == 0)
        {
            clonedPainting3 = Instantiate(Paintings[1], painting3Pos.position, painting3Pos.rotation);
            currIndex3 += 1;
            Debug.Log("Created Painting 2");
        }
        if (prevIndex3 == 1)
        {
            clonedPainting3 = Instantiate(Paintings[2], painting3Pos.position, painting3Pos.rotation);
            currIndex3 += 1;
            Debug.Log("Created Painting 3");
        }
        if (prevIndex3 == 2)
        {
            clonedPainting3 = Instantiate(Paintings[3], painting3Pos.position, painting3Pos.rotation);
            currIndex3 += 1;
            Debug.Log("Created Painting 4");
        }
        if (prevIndex3 == 3)
        {
            clonedPainting3 = Instantiate(Paintings[4], painting3Pos.position, painting3Pos.rotation);
            currIndex3 += 1;
            Debug.Log("Created Painting 5");
        }
    }

    public void ShiftPainting4()
    {
        Destroy(clonedPainting4);
        Debug.Log("Destroyed");
        B4Anim.SetBool("Button4Pressed", true);
        Invoke(nameof(ResetAnimations), 0.4f);
        canPress = false;
        Invoke(nameof(PressReset), 0.4f);

        if (prevIndex4 == -1)
        {
            clonedPainting4 = Instantiate(Paintings[0], painting4Pos.position, painting4Pos.rotation);
            currIndex4 += 1;
            Debug.Log("Created Painting 1");
        }
        if (prevIndex4 == 0)
        {
            clonedPainting4 = Instantiate(Paintings[1], painting4Pos.position, painting4Pos.rotation);
            currIndex4 += 1;
            Debug.Log("Created Painting 2");
        }
        if (prevIndex4 == 1)
        {
            clonedPainting4 = Instantiate(Paintings[2], painting4Pos.position, painting4Pos.rotation);
            currIndex4 += 1;
            Debug.Log("Created Painting 3");
        }
        if (prevIndex4 == 2)
        {
            clonedPainting4 = Instantiate(Paintings[3], painting4Pos.position, painting4Pos.rotation);
            currIndex4 += 1;
            Debug.Log("Created Painting 4");
        }
        if (prevIndex4 == 3)
        {
            clonedPainting4 = Instantiate(Paintings[4], painting4Pos.position, painting4Pos.rotation);
            currIndex4 += 1;
            Debug.Log("Created Painting 5");
        }
    }
    public void ShiftPainting5()
    {
        Destroy(clonedPainting5);
        Debug.Log("Destroyed");
        B5Anim.SetBool("Button5Pressed", true);
        Invoke(nameof(ResetAnimations), 0.4f);
        canPress = false;
        Invoke(nameof(PressReset), 0.4f);

        if (prevIndex5 == -1)
        {
            clonedPainting5 = Instantiate(Paintings[0], painting5Pos.position, painting5Pos.rotation);
            currIndex5 += 1;
            Debug.Log("Created Painting 1");
        }
        if (prevIndex5 == 0)
        {
            clonedPainting5 = Instantiate(Paintings[1], painting5Pos.position, painting5Pos.rotation);
            currIndex5 += 1;
            Debug.Log("Created Painting 2");
        }
        if (prevIndex5 == 1)
        {
            clonedPainting5 = Instantiate(Paintings[2], painting5Pos.position, painting5Pos.rotation);
            currIndex5 += 1;
            Debug.Log("Created Painting 3");
        }
        if (prevIndex5 == 2)
        {
            clonedPainting5 = Instantiate(Paintings[3], painting5Pos.position, painting5Pos.rotation);
            currIndex5 += 1;
            Debug.Log("Created Painting 4");
        }
        if (prevIndex5 == 3)
        {
            clonedPainting5 = Instantiate(Paintings[4], painting5Pos.position, painting5Pos.rotation);
            currIndex5 += 1;
            Debug.Log("Created Painting 5");
        }
    }

    public void ResetAnimations()
    {
        B1Anim.SetBool("Button1Pressed", false);
        B2Anim.SetBool("Button2Pressed", false);
        B3Anim.SetBool("Button3Pressed", false);
        B4Anim.SetBool("Button4Pressed", false);
        B5Anim.SetBool("Button5Pressed", false);
    }

    public void PressReset()
    {
        canPress = true;
    }
    public void SoundOff()
    {
        SlideSound.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PaintB1"))
        {
            canPress1 = true;
        }
        if (other.CompareTag("PaintB2"))
        {
            canPress2 = true;
        }
        if (other.CompareTag("PaintB3"))
        {
            canPress3 = true;
        }
        if (other.CompareTag("PaintB4"))
        {
            canPress4 = true;
        }
        if (other.CompareTag("PaintB5"))
        {
            canPress5 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PaintB1"))
        {
            canPress1 = false;
        }
        if (other.CompareTag("PaintB2"))
        {
            canPress2 = false;
        }
        if (other.CompareTag("PaintB3"))
        {
            canPress3 = false;
        }
        if (other.CompareTag("PaintB4"))
        {
            canPress4 = false;
        }
        if (other.CompareTag("PaintB5"))
        {
            canPress5 = false;
        }
    }
    public void PuzzleCompletion()
    {
        Debug.Log("Puzzle Complete!");
    }
}
