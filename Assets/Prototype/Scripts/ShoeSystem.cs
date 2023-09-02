using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeSystem : MonoBehaviour
{
    MeshRenderer mesh;
    float cooldown = 0;
    bool isShaking = false;
    
    public float maxCooldown = 1;
    public float shakeDuration;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Shake();

        if(cooldown <= 0)
        {
            mesh.enabled=false;

            if (Input.GetKeyDown("space"))
            {
                mesh.enabled=true;
                cooldown = maxCooldown;
                isShaking = true;
            }
            //If collides with paper
            //Apply win effects (particles, screenshake, sounds)
    
            //If not
            //Apply subdued effects
        }
        else
        {
            cooldown -= Time.deltaTime;
            //Fade out shoe renderer
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(cooldown <= 0)
        {
            Debug.Log("Hit");
        }
    }

    void Shake()
    {

    }

}