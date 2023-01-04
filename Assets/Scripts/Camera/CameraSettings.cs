using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings 
{
    public float sensitivity;
    public float up;
    public float zoom;
    public float xEulerAngles;

    public CameraSettings(float cameraSensitivity, float cameraUp, float cameraZoom, float cameraXEulerAngles)
    {
        sensitivity = cameraSensitivity;
        up = cameraUp;
        zoom = cameraZoom;
        xEulerAngles = cameraXEulerAngles;
    }
}
