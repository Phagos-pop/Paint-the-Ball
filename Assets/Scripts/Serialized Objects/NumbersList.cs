using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GolgHoleNumber", menuName = "SerObj/NumberList", order = 0)]
public class NumbersList : ScriptableObject
{
    public List<GameObject> Numbers = new List<GameObject>();
}
