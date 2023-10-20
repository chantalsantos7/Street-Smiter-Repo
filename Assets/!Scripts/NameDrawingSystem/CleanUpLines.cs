using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpLines : MonoBehaviour
{
    public void DeleteGameObjects()
    {
        var lines = GameObject.FindGameObjectsWithTag("DrawnLine");
        foreach (var line in lines)
        {
            Destroy(line);
        }
    }
}
