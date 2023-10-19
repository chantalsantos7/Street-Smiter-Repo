using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    HitSystem hitSystem;

    public float cooldown = 0;
    public float maxCooldown = 1;
    public bool onCooldown;

    void Start()
    {
        hitSystem = GameObject.Find("Shoe").GetComponent<HitSystem>();
    }

    void Update()
    {
        if(cooldown > 0) {onCooldown = true;}
        else {onCooldown = false;}

        if(onCooldown) {cooldown -= Time.deltaTime;}

        if(Input.GetKeyDown("space") && !onCooldown) 
        {
            cooldown = maxCooldown;
            hitSystem.CheckHit();
        }
    }
}