using UnityEngine;

public class Hide : MonoBehaviour
{
    public Camera playerCamera; // Assign the player camera in the Inspector
    public float lookAwayThreshold = 45f; // Adjust this threshold angle as needed

    private void Update()
    {
        // Check if the object is within the specified angle range from the camera's forward vector
        Vector3 toObject = transform.position - playerCamera.transform.position;
        float angle = Vector3.Angle(playerCamera.transform.forward, toObject);

        // If the object is outside the threshold, disable it
        if (angle > lookAwayThreshold)
        {
            gameObject.SetActive(false);
        }
        else
        {
            // If the object comes back into view, enable it
            gameObject.SetActive(true);
        }
    }
}