using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private float inpulseToDestoy;

    private new Renderer renderer;
    private float initialInpulseToDestoy;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        initialInpulseToDestoy = inpulseToDestoy - inpulseToDestoy / 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float magnitude = collision.impulse.magnitude;
        IBall ball = collision.gameObject.GetComponent<IBall>();

        if (ball != null)
        {
            ChengeColor(magnitude, ball.GetMaterial().color);
        }

        inpulseToDestoy -= magnitude;
        if (inpulseToDestoy < 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Wall destroyed");
        }
    }

    private void ChengeColor(float magnitude,Color color)
    {
        float colorminus = magnitude / initialInpulseToDestoy;
        Color newColor = Color.Lerp(renderer.material.color, color, colorminus);

        //Debug.Log($"old color {renderer.material.color}; new color {newColor}; magnitude {magnitude}; colorminus  {colorminus}");
        renderer.material.color = newColor;
    }
}
