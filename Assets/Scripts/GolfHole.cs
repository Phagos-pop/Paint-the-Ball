using System;

using UnityEngine;

public class GolfHole : MonoBehaviour
{
    private Renderer renderer;
    public event Action<Color> BallDeadEvent;

    private void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        IBall ball = collision.gameObject.GetComponent<IBall>();
        if (ball == null)
        {
            return;
        }
        if (ball.MaterialComparison(renderer.material))
        {
            BallDeadEvent?.Invoke(ball.GetMaterial().color);
            ball.DeleteBall();
        }
    }
}
