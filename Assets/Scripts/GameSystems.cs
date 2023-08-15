using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystems : MonoBehaviour
{
    public static GameSystems Instance { get; private set; }
    public DialogueSystem DialogueSystem { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DialogueSystem = GetComponentInChildren<DialogueSystem>();
    }
}
