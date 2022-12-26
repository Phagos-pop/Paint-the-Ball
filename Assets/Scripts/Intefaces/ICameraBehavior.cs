
using UnityEngine;

public interface ICameraBehavior 
{
    void Enter(CameraSettings cameraSettings, Transform target);

    void Exit();

    void Update();
}
