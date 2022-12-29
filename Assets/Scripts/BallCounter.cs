using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    [SerializeField] Material redMaterial;
    [SerializeField] Material greenMaterial;
    [SerializeField] Material yellowMaterial;

    private int redCount;
    private int greenCount;
    private int yellowCount;

    private List<GolfHole> golfHoles = new List<GolfHole>();
    public event Action<BallColorType,int> BallDeadEvent;

    private void Start()
    {
        InitGolfHoles();
    }

    private void InitGolfHoles()
    {
        golfHoles = FindObjectsOfType<GolfHole>().ToList();
        foreach (var golfHole in golfHoles)
        {
            golfHole.BallDeadEvent += GolfHole_BallDeadEvent;
        }
    }

    private void GolfHole_BallDeadEvent(Color color)
    {
        if (color == redMaterial.color)
        {
            redCount++;
            BallDeadEvent?.Invoke(BallColorType.Red,redCount);
        }
        else if (color == greenMaterial.color)
        {
            greenCount++;
            BallDeadEvent?.Invoke(BallColorType.Green,greenCount);
        }
        else if (color == yellowMaterial.color)
        {
            yellowCount++;
            BallDeadEvent?.Invoke(BallColorType.Yellow,yellowCount);
        }
    }
}

public enum BallColorType
{
    Red,
    Yellow,
    Green
}
