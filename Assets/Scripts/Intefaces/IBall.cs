
using UnityEngine;

public interface IBall
{
    public Material GetMaterial();
    public void SetMaterial(Material material);
    public bool MaterialComparison(Material material);
    public void DeleteBall();
}
