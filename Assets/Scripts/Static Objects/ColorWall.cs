using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour
{
    private new Renderer renderer;

    private bool isOpen;

    public void Init(Color color)
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        isOpen = false;
    }

    public void Open()
    {
        if (!isOpen)
        {
            Debug.Log($"Open wall ");
            transform.position = new Vector3(transform.position.x, transform.localScale.y + transform.position.y, transform.position.z);
        }
    }
}
