using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float sensitivity;
    [SerializeField] private float up;
    [SerializeField] private float zoom;
    [SerializeField] private float xEulerAngles;

    private CameraSettings cameraSettings;
    private ICameraBehavior currentCameraBehivior;
    private Dictionary<Type, ICameraBehavior> beheviorMap;
    private Camera mainCamera;

    public event Action ClickEvent;

    private void Start()
    {
        mainCamera = Camera.main;
        InitCameraSettings();
        InitCameraBehevior();
        SetBeheviorByDefult();
    }

    private void Update()
    {
        if (currentCameraBehivior != null)
        {
            currentCameraBehivior.Update();
        }

        if (Input.GetMouseButtonDown(0))
        {
            ClickEvent?.Invoke();
        }
    }

    #region CameraBehavior
    private void InitCameraSettings()
    {
        cameraSettings = new CameraSettings(sensitivity, up, zoom, xEulerAngles);
    }

    private void SetBeheviorByDefult()
    {
        SetCameraRotateBehevior();
    }

    private void InitCameraBehevior()
    {
        this.beheviorMap = new Dictionary<Type, ICameraBehavior>();

        this.beheviorMap[typeof(CameraRotateBehevior)] = new CameraRotateBehevior();
        this.beheviorMap[typeof(CameraStaticBehevior)] = new CameraStaticBehevior();
        this.beheviorMap[typeof(CameraLowRotateBehevior)] = new CameraLowRotateBehevior();
    }

    private void SetBehevior(ICameraBehavior newCameraBehivior)
    {
        if (this.currentCameraBehivior != null)
        {
            this.currentCameraBehivior.Exit();
        }
        this.currentCameraBehivior = newCameraBehivior;
        this.currentCameraBehivior.Enter(cameraSettings, target);
    }

    private ICameraBehavior GetBehivior<T>() where T : ICameraBehavior
    {
        var type = typeof(T);
        return this.beheviorMap[type];
    }

    public void SetCameraRotateBehevior()
    {
        var behevior = this.GetBehivior<CameraRotateBehevior>();
        this.SetBehevior(behevior);
    }

    public void SetCameraLowRotateBehevior()
    {
        var behevior = this.GetBehivior<CameraLowRotateBehevior>();
        this.SetBehevior(behevior);
    }

    public void SetCameraStaticBehevior()
    {
        var behevior = this.GetBehivior<CameraStaticBehevior>();
        this.SetBehevior(behevior);
    }
    #endregion
}
