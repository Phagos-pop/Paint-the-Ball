using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointer : MonoBehaviour
{
    private Transform mainBallTranform;
    private Camera mainCamera;
    [SerializeField] private Transform iconTransform;

    private void Start()
    {
        mainBallTranform = FindObjectOfType<MainBall>().transform;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 fromMainBallToStar = this.transform.position - mainBallTranform.position;
        Ray ray = new Ray(mainBallTranform.position, fromMainBallToStar);

        Debug.DrawRay(mainBallTranform.position, fromMainBallToStar);

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        float minDistance = float.MaxValue;

        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0f, fromMainBallToStar.magnitude);
        if (fromMainBallToStar.magnitude > minDistance)
        {
            iconTransform.gameObject.SetActive(true);
            iconTransform.position = mainCamera.WorldToScreenPoint(ray.GetPoint(minDistance));
        }
        else
        {
            iconTransform.gameObject.SetActive(false);
            return;
        }

    }
}