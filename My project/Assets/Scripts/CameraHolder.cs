using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraPos;

    private void Update()
    {
        transform.position = cameraPos.position;
    }
}
