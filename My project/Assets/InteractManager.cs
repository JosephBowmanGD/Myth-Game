using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject interactionUI2;
    public float interactionDistance = 2f;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance))
        {
            ItemInteract itemInteract = hit.collider.GetComponent<ItemInteract>();
            if (itemInteract != null)
            {
                // Show the interaction UI
                interactionUI.SetActive(true);
                interactionUI2.SetActive(true);

                // Handle input for interaction (e.g., press a button)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    itemInteract.Interact();
                }
            }
            else
            {
                // Hide the interaction UI if not looking at an interactable object
                interactionUI.SetActive(false);
                interactionUI2.SetActive(false);
            }
        }
        else
        {
            // Hide the interaction UI if not looking at anything
            interactionUI.SetActive(false);
            interactionUI2.SetActive(false);
        }
    }
}
