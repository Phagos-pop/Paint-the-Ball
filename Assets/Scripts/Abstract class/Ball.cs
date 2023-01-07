
using UnityEngine;

public abstract class Ball : MonoBehaviour, IBall
{
    public new Renderer renderer;

    public void Init()
    {
        renderer = GetComponent<Renderer>();
    }

    public Material GetMaterial()
    {
        return renderer.material;
    }

    public virtual void DeleteBall()
    {
        Destroy(this.gameObject);
    }

    public void SetMaterial(Material material)
    {
        this.renderer.material = material;
    }

    public bool MaterialComparison(Material material)
    {
        return renderer.material.color == material.color;
    }
}
