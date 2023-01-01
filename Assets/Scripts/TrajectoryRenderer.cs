using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 direction)
    {
        Vector3[] points = new Vector3[300];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.01f;

            points[i] = origin + new Vector3(direction.x * time, 0, direction.z * time);
            Ray ray = new Ray(points[i], new Vector3(direction.x * (time + 0.01f), 0, direction.z * (time + 0.01f)));
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.distance < 1 && !raycastHit.collider.isTrigger)
                {
                    lineRenderer.positionCount = i + 1;
                    break;
                }
            }
        }

        lineRenderer.SetPositions(points);
    }

    public void SetMaterial(Color color)
    {
        lineRenderer.endColor = color;
    }
}
