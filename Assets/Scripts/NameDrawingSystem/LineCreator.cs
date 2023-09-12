using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] Transform lineParent;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Creating new line");
            Instantiate(linePrefab);
        }
    }
}
