using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 2.0f;
    public GameObject camera;

    private Quaternion initialRotation;
    private Vector3 initialPosition;

    void Start()
    {
        initialRotation = camera.transform.rotation;
        initialPosition = camera.transform.position;
    }

    void Update()
    {
        //lerp to target position and rotation
        Quaternion newRotation = Quaternion.Lerp(camera.transform.rotation, target.rotation, lerpSpeed * Time.deltaTime);
        Vector3 newPosition = Vector3.Lerp(camera.transform.position, target.position, lerpSpeed * Time.deltaTime);

        camera.transform.rotation = newRotation;
        camera.transform.position = newPosition;

        //When new pos+rot = target pos+rot fire some kind of complete event for other scripts to listen to
    }
}