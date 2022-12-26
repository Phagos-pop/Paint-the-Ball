using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        MainBall mainball = collision.gameObject.GetComponent<MainBall>();
        if (mainball != null)
        {
            renderer.material = mainball.GetMaterial();
        }
    }
    void Update()
    {
        
    }
}
