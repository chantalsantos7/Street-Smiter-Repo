using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueGroup", menuName = "ScriptableObjects/DialogueGroup", order = 1)]
public class DialogueGroup : ScriptableObject
{
    public string name;
    [TextArea(3, 10)]
    public List<string> dialogueLines = new List<string>();
}
