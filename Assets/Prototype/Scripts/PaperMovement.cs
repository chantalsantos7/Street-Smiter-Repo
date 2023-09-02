using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMovement : MonoBehaviour
{
    Vector3 minPos = new Vector3();
    Vector3 maxPos = new Vector3();
    Vector3 target = new Vector3();
    Camera cam;
    float elapsedTime = 0.0f;
    
    public float speed = 1;
    public AnimationCurve smoothing;

    void Start()
    {
        DefineArea();
        SetNewTarget();
    }

    void Update()
    {
        if(transform.position == target){SetNewTarget();}
        Move();
    }

    void DefineArea()
    {
        cam = Camera.main;
        //Sets the minimum target position to be the worldspace equivalent of 0,0 in screenspace with a value of 10 in the z position to account for the camera being -10 in worldspace
        //10 here should be changed to a variable that calculates the distance from the camera to the table.
        //Take table game object, then minus it's transform from the cameras, this should give you the correct depth offset.
        minPos = cam.ScreenToWorldPoint(new Vector3(0, 0, 10));
        maxPos = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
    }

    void SetNewTarget()
    {
        target = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0);
        elapsedTime = 0.0f;
    }

    void Move()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / speed);
        transform.position = Vector3.Lerp(transform.position, target, smoothing.Evaluate(t));
    }
}
