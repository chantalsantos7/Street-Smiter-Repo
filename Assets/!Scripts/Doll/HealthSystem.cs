using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    DollStats stats;

    public int damage = 20;

    void Start()
    {
        stats = GameObject.Find("Doll").GetComponent<DollStats>();
    }

    public void TakeDamage()
    {
        stats.health -= damage;
        print(stats.health);
    }
}