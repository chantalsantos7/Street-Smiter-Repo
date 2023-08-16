using UnityEngine;
using UnityEngine.EventSystems;

public class DialoguePanelClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Panel can be clicked");
        DialogueSystem.DialoguePanelClick.Invoke();
    }
}
