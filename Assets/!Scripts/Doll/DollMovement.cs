using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollMovement : MonoBehaviour
{
    Vector3 minPos = new Vector3();
    Vector3 maxPos = new Vector3();
    Vector3 target = new Vector3();
    Camera cam;
    float elapsedTime = 0.0f;
    DollStats stats;

    public float depth = 10;

    void Start()
    {
        stats = this.GetComponent<DollStats>();
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
        minPos = cam.ScreenToWorldPoint(new Vector3(0, 0, depth));
        maxPos = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, depth));
    }

    void SetNewTarget()
    {
        target = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0);
        elapsedTime = 0.0f;
    }

    void Move()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / stats.moveDuration);
        transform.position = Vector3.Lerp(transform.position, target, stats.moveSmoothing.Evaluate(t));
    }
}