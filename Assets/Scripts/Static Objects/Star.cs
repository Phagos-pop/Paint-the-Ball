using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public event Action FindStarEvent;

    private void OnTriggerEnter(Collider other)
    {
        IBall ball = other.GetComponent<IBall>();
        if (ball == null)
        {
            return;
        }

        FindStarEvent?.Invoke();
        Destroy(this.gameObject);
    }
}
