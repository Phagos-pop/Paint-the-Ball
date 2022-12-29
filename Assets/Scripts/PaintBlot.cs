
using UnityEngine;

public class PaintBlot : MonoBehaviour
{
    private Renderer renderer;

    private void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        IBall mainball = collision.gameObject.GetComponent<IBall>();
        if (mainball != null)
        {
            mainball.SetMaterial(renderer.material);
        }
    }
}
