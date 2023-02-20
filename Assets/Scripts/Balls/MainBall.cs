using System;
using UnityEngine;

public class MainBall : Ball
{
    [SerializeField] private float Multipl = 10;

    private Rigidbody _rb;
    private Camera mainCamera;
    private Vector3 kickVector;

    public TrajectoryRenderer trajectoryRenderer;

    public event Action DeathEvent;
    

    private void Start()
    {
        Init();
        _rb = this.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        
    }

    private void Update()
    {
        GetKickVector();
        trajectoryRenderer.ShowTrajectory(transform.position, kickVector);
        trajectoryRenderer.SetColor(renderer.material.color);
    }

    public void StopBall()
    {
        _rb.Sleep();
        _rb.WakeUp();
    }

    public void KickBall(float kickMultiplier)
    {
        kickMultiplier *= Multipl;
        _rb.AddForce(new Vector3(kickVector.x * kickMultiplier, kickVector.y, kickVector.z * kickMultiplier), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IBall ball = collision.gameObject.GetComponent<IBall>();
        ball?.SetMaterial(renderer.material);
    }

    private void GetKickVector()
    {
        kickVector = -(mainCamera.transform.position - transform.position);
        kickVector.y = transform.position.y;   
    }

    public override void DeleteBall()
    {
        DeathEvent?.Invoke();
        base.DeleteBall();
    }
}
