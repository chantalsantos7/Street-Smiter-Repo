using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitSystem : MonoBehaviour
{
    Collider areaCollider;
    ParticlesSystem particles;
    ShakeSystem screenShake;
    AudioSystem audio;
    HealthSystem health;

    public Transform objectToCheck;

    void Start()
    {
        areaCollider = this.GetComponent<Collider>();
        particles = GameObject.Find("ParticleManager").GetComponent<ParticlesSystem>();
        screenShake = GameObject.Find("CameraManager").GetComponent<ShakeSystem>();
        audio = GameObject.Find("AudioManager").GetComponent<AudioSystem>();
        health = GameObject.Find("Doll").GetComponent<HealthSystem>();
    }

    public void CheckHit()
    {
        if (areaCollider.bounds.Contains(objectToCheck.position)) 
        {
            print("Hit!");
            particles.PlayHitEffects();
            screenShake.Shake();
            audio.PlayHitAudio();
            health.TakeDamage();
        }
        else
        {
            print("Miss");
        }
    }
}