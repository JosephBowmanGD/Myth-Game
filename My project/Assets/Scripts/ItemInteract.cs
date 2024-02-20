using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInteract : MonoBehaviour
{
    public TextMeshProUGUI UICount;
    public GameObject UIItemDes;
    public int count;
    public UIController UI;

    public void Interact()
    {
        gameObject.SetActive(false);
        UICount.text = ("Items Collected" + " " + count + "/4");
        UIItemDes.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (count == 1)
            UI.one = true;
        else if(count == 2)
        {
            UI.one = false;
            UI.two = true;
        }
        else if(count == 3)
        {
            UI.two = false;
            UI.three = true;
        }
        else if( count == 4)
        {
            UI.three = false;
            UI.four = true;
        }

    }
}
