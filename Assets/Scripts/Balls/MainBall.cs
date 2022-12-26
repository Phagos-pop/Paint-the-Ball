using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBall : MonoBehaviour
{
    private Rigidbody _rb;
    private Camera mainCamera;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        _rb = this.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {

    }

    public void StopBall()
    {
        _rb.Sleep();
    }

    public void KickBall(float kickMultiplier)
    {
        kickMultiplier *= 10;
        float Y = transform.position.y;
        Vector3 kickVector = -(mainCamera.transform.position - transform.position);
        kickVector.y = Y;
        _rb.AddForce(new Vector3(kickVector.x * kickMultiplier, kickVector.y, kickVector.z * kickMultiplier), ForceMode.Impulse);
    }

    public Material GetMaterial()
    {
        return renderer.material;
    }
}
