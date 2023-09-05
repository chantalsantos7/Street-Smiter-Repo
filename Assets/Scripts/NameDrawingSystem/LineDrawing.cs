using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 previousPosition;

    [SerializeField] private float minDistance = 0.1f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        previousPosition = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("LineWriting registered");
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(currentPosition);
            currentPosition.z = 0f;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                if (previousPosition == transform.position)
                {
                    lineRenderer.SetPosition(0, currentPosition);
                }
                else
                {
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
                }

                previousPosition = currentPosition;
            }
        }
    }
}
