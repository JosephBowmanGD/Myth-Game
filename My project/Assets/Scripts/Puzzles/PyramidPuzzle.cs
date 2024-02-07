using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PyramidPuzzle : MonoBehaviour
{
    [Header("Input")]
    public KeyCode input;

    [Header("Rotation Values")]
    public float rotationSpeed;
    public float rotateAngleA;
    public float rotateAngleB;
    public float rotateAngleC;
    public float rotateAngleD;
    public float currRotationA;
    public float currRotationB;
    public float currRotationC;
    public float currRotationD;

    [Header("Rotation Bools")]
    public bool rotatingA;
    public bool rotatingB;
    public bool rotatingC;
    public bool rotatingD;

    [Header("Complete Conditions")]
    public bool called;

    [Header("Segments")]
    public GameObject SegA;
    public GameObject SegB;
    public GameObject SegC;
    public GameObject SegD;

    [Header("References")]
    public PyramidPuzzleButtons buttons;

    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;

    public bool canInput;

    void Start()
    {
        buttons = FindObjectOfType<PyramidPuzzleButtons>();
    }

    void Update()
    {
        currRotationA = SegA.transform.rotation.eulerAngles.y;
        currRotationB = SegB.transform.rotation.eulerAngles.y;
        currRotationC = SegC.transform.rotation.eulerAngles.y;
        currRotationD = SegD.transform.rotation.eulerAngles.y;

        // rotations
        if(canInput)
        {
            if (Input.GetKeyDown(input) && buttons.canPressA == true)
            {
                rotatingA = true;
                animator1.SetBool("Should Start", true);
                Invoke(nameof(ResetAnimator), 0.8f);
            }
            if (Input.GetKeyDown(input) && buttons.canPressB == true)
            {
                rotatingB = true;
                animator2.SetBool("Should Start", true);
                Invoke(nameof(ResetAnimator), 0.8f);
            }
            if (Input.GetKeyDown(input) && buttons.canPressC == true)
            {
                rotatingC = true;
                animator3.SetBool("Should Start", true);
                Invoke(nameof(ResetAnimator), 0.8f);
            }
            if (Input.GetKeyDown(input) && buttons.canPressD == true)
            {
                rotatingD = true;
                animator4.SetBool("Should Start", true);
                Invoke(nameof(ResetAnimator), 0.8f);
            }
        }

        if (rotatingA == true)
        {
            RotateSegA();
        }
        if (rotatingB == true)
        {
            RotateSegB();
        }
        if (rotatingC == true)
        {
            RotateSegC();
        }
        if (rotatingD == true)
        {
            RotateSegD();
        }
        
        //complete conditions
        if (currRotationA > 89 && currRotationA < 91 && currRotationB > 89 && currRotationB < 91 && currRotationC > 89 && currRotationC < 91 && currRotationD > 89 && currRotationD < 91)
        {
            if (!called)
            {
                Complete();
                called = true;
            }
        }

        if (rotatingA || rotatingB || rotatingC || rotatingD)
            canInput = false;
        else
            canInput = true;
    }

    public void RotateSegA()
    {
        Quaternion targetRotationB = Quaternion.Euler(0, rotateAngleA, 0);

        SegA.transform.rotation = Quaternion.Slerp(SegA.transform.rotation, targetRotationB, rotationSpeed * Time.deltaTime);

        if(SegA.transform.rotation == targetRotationB)
        {
            rotatingA = false;
            rotateAngleA -= 90;
        }
    }

    public void RotateSegB()
    {
        Quaternion targetRotationM = Quaternion.Euler(0, rotateAngleB, 0);

        SegB.transform.rotation = Quaternion.Slerp(SegB.transform.rotation, targetRotationM, rotationSpeed * Time.deltaTime);

        if (SegB.transform.rotation == targetRotationM)
        {
            rotatingB = false;
            rotateAngleB += 90;
        }
    }
    public void RotateSegC()
    {
        Quaternion targetRotationC = Quaternion.Euler(0, rotateAngleC, 0);

        SegC.transform.rotation = Quaternion.Slerp(SegC.transform.rotation, targetRotationC, rotationSpeed * Time.deltaTime);

        if (SegC.transform.rotation == targetRotationC)
        {
            rotatingC = false;
            rotateAngleC -= 90;
        }
    }

    public void RotateSegD()
    {
        Quaternion targetRotationT = Quaternion.Euler(0, rotateAngleD, 0);

        SegD.transform.rotation = Quaternion.Slerp(SegD.transform.rotation, targetRotationT, rotationSpeed * Time.deltaTime);

        if (SegD.transform.rotation == targetRotationT)
        {
            rotatingD = false;
            rotateAngleD += 90;
        }
    }
    public void Complete()
    {
        Debug.Log("Puzzle Complete!");
    }

    public void ResetAnimator()
    {
            animator1.SetBool("Should End", true);
            animator1.SetBool("Should Start", false);
            animator2.SetBool("Should End", true);
            animator2.SetBool("Should Start", false);
            animator3.SetBool("Should End", true);
            animator3.SetBool("Should Start", false);
            animator4.SetBool("Should End", true);
            animator4.SetBool("Should Start", false);
    }
}