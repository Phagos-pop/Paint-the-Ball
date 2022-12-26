using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateBehevior : ICameraBehavior
{
    CameraSettings currentCameraSettings;
    private Camera mainCamera;
    private Vector3 offset;
    private Transform target;
    private float X;

    public void Enter(CameraSettings cameraSettings, Transform target)
    {
        this.target = target;
        mainCamera = Camera.main;
        currentCameraSettings = cameraSettings;
        offset = new Vector3(offset.x, offset.y, -currentCameraSettings.zoom);
        mainCamera.transform.position = target.position + offset;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            X = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * currentCameraSettings.sensitivity;
            mainCamera.transform.localEulerAngles = new Vector3(0f, X, 0f);
            mainCamera.transform.position = mainCamera.transform.localRotation * offset + target.position;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, target.position.y + currentCameraSettings.up, mainCamera.transform.position.z);
        }
        else
        {
            X = mainCamera.transform.localEulerAngles.y;
            mainCamera.transform.localEulerAngles = new Vector3(0f, X, 0f);
            mainCamera.transform.position = mainCamera.transform.localRotation * offset + target.position;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, target.position.y + currentCameraSettings.up, mainCamera.transform.position.z);
        }
#else
            X = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * currentCameraSettings.sensitivity;
            mainCamera.transform.localEulerAngles = new Vector3(0f, X, 0f);
            mainCamera.transform.position = mainCamera.transform.localRotation * offset + target.position;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, target.position.y + currentCameraSettings.up, mainCamera.transform.position.z);
#endif
    }
}
