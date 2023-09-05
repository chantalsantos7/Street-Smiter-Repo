using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NameDrawingSystem
{
    public class Line : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private List<Vector2> linePoints;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        public void SetPoint(Vector2 point)
        {
            linePoints.Add(point);
            
            lineRenderer.positionCount = linePoints.Count;
            //Debug.Log();
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
        }

        public void UpdateLine(Vector2 position) 
        {
            Debug.Log("UpdateLine reached");
            if (linePoints == null)
            {
                linePoints = new List<Vector2>();
                SetPoint(position);
                return;
            }

            if (Vector2.Distance(linePoints.Last(), position) > 0.1f)
            {
                SetPoint(position);  
            }
        }
    }
}


