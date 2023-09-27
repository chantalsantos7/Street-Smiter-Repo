using UnityEngine;

[CreateAssetMenu(fileName = "LineColour", menuName = "ScriptableObjects/LineColour")]
public class LineColour : ScriptableObject
{
    public string colourName;
    [ColorUsage(true)] public Color Colour;
}
