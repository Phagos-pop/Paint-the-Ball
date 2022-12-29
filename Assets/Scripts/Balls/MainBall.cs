
using UnityEngine;

public class MainBall : Ball
{
    private Rigidbody _rb;
    private Camera mainCamera;

    private void Start()
    {
        Init();
        _rb = this.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
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

    private void OnCollisionEnter(Collision collision)
    {
        IBall ball = collision.gameObject.GetComponent<IBall>();
        ball?.SetMaterial(renderer.material);
    }
    public override void DeleteBall()
    {
        Debug.Log("Delete Main Ball");
        base.DeleteBall();
    }
}
