
using System.Collections;
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
        Color oldColor = renderer.material.color;
        this.renderer.material = material;
        StartCoroutine(SetMaterialCoroutine(material.color, oldColor, material));
    }

    private IEnumerator SetMaterialCoroutine(Color newColor, Color oldColor, Material material)
    {
        while (oldColor != newColor)
        {
            renderer.material.color = oldColor;
            yield return new WaitForSeconds(0.05f);
            oldColor = Color.Lerp(oldColor, newColor, 0.5f);
        }
        renderer.material = material;
    }

    public bool MaterialComparison(Material material)
    {
        return renderer.material.color.Equals(material.color); // == material.color;
        
    }
}
