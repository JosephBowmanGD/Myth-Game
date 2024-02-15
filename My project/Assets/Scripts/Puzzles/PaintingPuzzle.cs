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

    private bool called;
    void Start()
    {
        currIndex1 = 0;
        currIndex2 = 0;
        currIndex3 = 0;
        currIndex4 = 0;
        currIndex5 = 0;
        called = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !called)
        {
            ShiftPainting1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !called)
        {
            ShiftPainting2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !called )
        {
            ShiftPainting3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !called)
        {
            ShiftPainting4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && !called)
        {
            ShiftPainting5();
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
        if(currIndex1 == 1 && currIndex2 == 2 && currIndex3 == 3 && currIndex4 == 4 && currIndex5 == 0)
        {
            if (!called)
            {
                PuzzleCompletion();
                called = true;
            }
        }
    }

    public void ShiftPainting1()
    {
        Destroy(clonedPainting1);
        Debug.Log("Destroyed");


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
    public void PuzzleCompletion()
    {
        Debug.Log("Puzzle Complete!");
    }
}
