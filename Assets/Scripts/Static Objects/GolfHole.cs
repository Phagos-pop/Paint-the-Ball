using System;

using UnityEngine;

public class GolfHole : MonoBehaviour
{
    [SerializeField] private ColorWall colorWall;
    [SerializeField] private int countToAction;
    [SerializeField] private GolgHoleNumber holeNumber;

    private new Renderer renderer;
    public event Action<Color> BallDeadEvent;


    private void Start()
    {
        renderer = this.GetComponent<Renderer>();
        if (colorWall != null)
        {
            colorWall.Init(renderer.material.color);
        }
        holeNumber.SetNumber(countToAction, renderer.material);
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
            if (countToAction == 0)
            {
                return;
            }
            countToAction--;
            holeNumber.SetNumber(countToAction, renderer.material);
            BallDeadEvent?.Invoke(ball.GetMaterial().color);
            if (colorWall != null && countToAction == 0)
            {
                colorWall.Open();
            }
            ball.DeleteBall();
        }
    }
}
