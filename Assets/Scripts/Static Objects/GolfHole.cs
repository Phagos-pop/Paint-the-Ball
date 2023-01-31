using System;

using UnityEngine;

public class GolfHole : MonoBehaviour
{
    [SerializeField] private ColorWall colorWall;

    private new Renderer renderer;
    public event Action<Color> BallDeadEvent;


    private void Start()
    {
        renderer = this.GetComponent<Renderer>();
        if (colorWall != null)
        {
            colorWall.Init(renderer.material.color);
        }
    }

    private void Update()
    {
        //TODO 
        //float x = transform.position.x;
        //float y = Mathf.Sin(Time.time) + 2f;
        //float z = transform.position.z;
        //transform.position = new Vector3(x, y, z);
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
            if (colorWall != null)
            {
                colorWall.Open();
            }
            ball.DeleteBall();
        }
    }
}
