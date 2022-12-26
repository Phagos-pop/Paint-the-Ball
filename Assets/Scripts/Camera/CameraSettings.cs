using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings 
{
	public float sensitivity = 3;
	public float up = 3;
	public float zoom = 7.5f;

    public CameraSettings(float cameraSensitivity, float cameraUp, float cameraZoom)
    {
        sensitivity = cameraSensitivity;
        up = cameraUp;
        zoom = cameraZoom;
    }
}
