using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PyramidPuzzle : MonoBehaviour
{
    [Header("Input")]
    public KeyCode input;

    [Header("Rotation Values")]
    public float rotationSpeed;
    public float rotateAngleB;
    public float rotateAngleM;
    public float rotateAngleT;
    public float currRotationB;
    public float currRotationM;
    public float currRotationT;

    [Header("Rotation Bools")]
    public bool rotatingB;
    public bool rotatingM;
    public bool rotatingT;
    public bool canRotate;

    [Header("Complete Conditions")]
    public bool bottomComplete;
    public bool midComplete;
    public bool topComplete;
    public bool called;

    [Header("Segments")]
    public GameObject SegB;
    public GameObject SegM;
    public GameObject SegT;

    [Header("References")]
    public PyramidPuzzleButtons buttons;
    void Start()
    {
        canRotate = true;
        buttons = FindObjectOfType<PyramidPuzzleButtons>();

        bottomComplete = false;
        midComplete = false;
        topComplete = false;
    }
    void Update()
    {
        currRotationB = SegB.transform.rotation.eulerAngles.y;
        currRotationM = SegM.transform.rotation.eulerAngles.y;
        currRotationT = SegT.transform.rotation.eulerAngles.y;

        // rotations
        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressB == true)
        {
            rotatingB = true;
        }
        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressM == true)
        {
            rotatingM = true;
        }
        if (Input.GetKeyDown(input) && canRotate == true && buttons.canPressT == true)
        {
            rotatingT = true;
        }

        if (rotatingB == true)
        {
            RotateSegBot();
        }
        if(rotatingB == false)
        {
            canRotate = true;
        }

        if (rotatingM == true)
        {
            RotateSegMid();
        }
        if (rotatingM == false)
        {
            canRotate = true;
        }

        if (rotatingT == true)
        {
            RotateSegTop();
        }
        if (rotatingT == false)
        {
            canRotate = true;
        }
        
        //complete conditions
        if (currRotationB > 89 && currRotationB < 91)
        {
            bottomComplete = true;
        }
        else
        {
            bottomComplete = false;
        }
        if (currRotationM > 269 && currRotationM < 271)
        {
            midComplete = true;
        }
        else
        {
            midComplete = false;
        }
        if (currRotationT > 179 && currRotationT < 181)
        {
            topComplete = true;
        }
        else
        {
            topComplete = false;
        }

        if(bottomComplete && midComplete && topComplete)
        {
            if (!called)
            {
                Complete();
                called = true;
            }
        }

      
    }
    public void RotateSegBot()
    {
        Quaternion targetRotationB = Quaternion.Euler(0, rotateAngleB, 0);

        SegB.transform.rotation = Quaternion.Slerp(SegB.transform.rotation, targetRotationB, rotationSpeed * Time.deltaTime);

        if(SegB.transform.rotation == targetRotationB)
        {
            canRotate = false;
            rotatingB = false;
            rotateAngleB += 90;
        }
    }
    public void RotateSegMid()
    {
        Quaternion targetRotationM = Quaternion.Euler(0, rotateAngleM, 0);

        SegM.transform.rotation = Quaternion.Slerp(SegM.transform.rotation, targetRotationM, rotationSpeed * Time.deltaTime);



        if (SegM.transform.rotation == targetRotationM)
        {
            canRotate = false;
            rotatingM = false;
            rotateAngleM -= 90;
        }
    }
    public void RotateSegTop()
    {
        Quaternion targetRotationT = Quaternion.Euler(0, rotateAngleT, 0);

        SegT.transform.rotation = Quaternion.Slerp(SegT.transform.rotation, targetRotationT, rotationSpeed * Time.deltaTime);

        if (SegT.transform.rotation == targetRotationT)
        {
            canRotate = false;
            rotatingT = false;
            rotateAngleT += 90;
        }
    }
    public void Complete()
    {
        Debug.Log("Puzzle Complete!");
    }
}
