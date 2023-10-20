using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSystem : MonoBehaviour
{
    MeshRenderer mesh;
    InputSystem input;

    private float currentAlpha;

    public Material shoeMaterial;
    public SpriteRenderer shadowRenderer;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        input = GameObject.Find("InputManager").GetComponent<InputSystem>();
    }

    void Update()
    {
        if(input.onCooldown)
        {
            EnableMesh();
            FadeOut();
        }
        else
        {
            DisableMesh();
        }
    }

    void FadeOut()
    {
        //Lerp shoe's material alpha to 0
        float t = Mathf.Clamp01(input.cooldown / input.maxCooldown);
        currentAlpha = Mathf.Lerp(0.0f, 1.0f, t);
        shoeMaterial.color = new Color(shoeMaterial.color.r, shoeMaterial.color.g, shoeMaterial.color.b, currentAlpha);
    }

    void EnableMesh()
    {
        mesh.enabled = true;
    }

    void DisableMesh()
    {
        mesh.enabled = false;
    }
}