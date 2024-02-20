using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UIItemDes;
    public GameObject UIItemDes2;
    public GameObject UIItemDes3;
    public GameObject UIItemDes4;
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    private bool isFullscreen = false;

    void Start()
    {
        Debug.Log("UIController script started.");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFullscreen();
        }
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;

        if (isFullscreen)
        {
            // Switch to fullscreen mode
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            // Switch to windowed mode
            Screen.SetResolution(800, 600, false);
        }
    }

    public void Continue()
    {
        if(one)
        {
            if (UIItemDes != null)
                UIItemDes.SetActive(false);
        }
        else if(two)
        {
            if (UIItemDes2 != null)
                UIItemDes2.SetActive(false);
        }
        else if(three)
        {
            if (UIItemDes3 != null)
                UIItemDes3.SetActive(false);
        }
        else
        {
            if (UIItemDes4 != null)
                UIItemDes4.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
