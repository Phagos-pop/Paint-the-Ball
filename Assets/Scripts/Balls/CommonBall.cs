using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBall : Ball
{
    public void Awake()
    {
        Init();
    }

    public override void DeleteBall()
    {
        Debug.Log("Delete Ball");
        base.DeleteBall();
    }
}
