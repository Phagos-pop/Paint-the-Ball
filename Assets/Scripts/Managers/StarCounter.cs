using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

public class StarCounter : MonoBehaviour
{
    private List<Star> starList;
    private int countOfStar;

    public event Action<int> SetStarCountEvent;
    public event Action AllStarsCountedEvent;

    void Start()
    {
        starList = FindObjectsOfType<Star>().ToList();
        foreach (var star in starList)
        {
            star.FindStarEvent += Star_FindStarEvent;
        }

        countOfStar = starList.Capacity;
        SetStarCountEvent?.Invoke(countOfStar);
    }

    private void Star_FindStarEvent()
    {
        countOfStar--;
        SetStarCountEvent?.Invoke(countOfStar);
        if (countOfStar == 0)
        {
            AllStarsCountedEvent?.Invoke();
        }
    }
}
