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
    public bool canRotate;

    [Header("Complete Conditions")]
    public bool AComplete;
    public bool BComplete;
    public bool CComplete;
    public bool DComplete;
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

    void Start()
    {
        buttons = FindObjectOfType<PyramidPuzzleButtons>();
        canRotate = false;
        AComplete = false;
        BComplete = false;
        CComplete = false;
        DComplete = false;
    }
    void Update()
    {
        currRotationA = SegA.transform.rotation.eulerAngles.y;
        currRotationB = SegB.transform.rotation.eulerAngles.y;
        currRotationC = SegC.transform.rotation.eulerAngles.y;
        currRotationD = SegD.transform.rotation.eulerAngles.y;
        

        // rotations
        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressA == true)
        {
            rotatingA = true;
        }

        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressB == true)
        {
            rotatingB = true;
        }

        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressC == true)
        {
            rotatingC = true;
        }

        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressD == true)
        {
            rotatingD = true;
        }


        if (rotatingA == true)
        {
            RotateSegA();
        }
        if(rotatingA == false)
        {
            canRotate = true;
        }
        if (rotatingB == true)
        {
            RotateSegB();
        }
        if (rotatingB == false)
        {
            canRotate = true;
        }
        if (rotatingC == true)
        {
            RotateSegC();
        }
        if (rotatingC == false)
        {
            canRotate = true;

        }

        if (rotatingD == true)
        {
            RotateSegD();
            canRotate = false;
        }
        if (rotatingD == false)
        {
            canRotate = true;
        }
        
        //complete conditions
        if (currRotationA > 89 && currRotationA < 91)
        {
            AComplete = true;
        }
        else
        {
            AComplete = false;
        }
        if (currRotationB > 89 && currRotationB < 91)
        {
            BComplete = true;
        }
        else
        {
            BComplete = false;
        }
        if (currRotationC > 89 && currRotationC < 91)
        {
            CComplete = true;
        }
        else
        {
            DComplete = false;
        }
        if (currRotationD > 89 && currRotationD < 91)
        {
            DComplete = true;
        }
        else
        {
            DComplete = false;
        }

        if(AComplete && BComplete && CComplete && DComplete)
        {
            if (!called)
            {
                Complete();
                called = true;
            }
        }
    }
    public void RotateSegA()
    {
        Quaternion targetRotationB = Quaternion.Euler(0, rotateAngleA, 0);

        SegA.transform.rotation = Quaternion.Slerp(SegA.transform.rotation, targetRotationB, rotationSpeed * Time.deltaTime);

        if(SegA.transform.rotation == targetRotationB)
        {
            canRotate = false;
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
            canRotate = false;
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
            canRotate = false;
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
            canRotate = false;
            rotatingD = false;
            rotateAngleD += 90;
        }
    }
    public void Complete()
    {
        Debug.Log("Puzzle Complete!");
    }
}
