using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GolgHoleNumber : MonoBehaviour
{
    [SerializeField]private NumbersList numbersList;
    [SerializeField] private GameObject numberOBJ;

    private new Renderer renderer;

    public void SetNumber(int number,  Material material)
    {
        Transform transform = numberOBJ.transform;
        Destroy(numberOBJ);
        numberOBJ = Instantiate(numbersList.Numbers[number], this.transform);
        numberOBJ.transform.position = transform.position;
        numberOBJ.transform.rotation = transform.rotation;
        numberOBJ.transform.localScale = transform.localScale;
        renderer = numberOBJ.GetComponent<Renderer>();
        renderer.material = material;
    }
}
