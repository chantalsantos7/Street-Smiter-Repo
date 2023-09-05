using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using StreetSmiterEventSystem;

public class DialogueSystem : MonoBehaviour
{
    public static Action DialoguePanelClick; //Invoked on a seperate script so when the player clicks/taps the dialogue panel, dialogue will progress to the next stage.

    [Tooltip("Interval between letters appearing on the dialogue screen - a smaller number will make the text appear faster.")]
    public float textTimeInterval;

    public TMPro.TextMeshProUGUI textDisplay;
    public GameObject dialoguePanel;

    private bool isDialogueActive = false;
    private List<string> dialogueLines = new List<string>();

    public AudioClip[] audioClips = new AudioClip[8];
    [SerializeField] private AudioSource _audioSource;
    public void Awake()
    {
        DialoguePanelClick += DisplayNextDialogueMessage;
        DisplayDialoguePanel(false);
    }

    //Starts the process of displaying the dialogue on screen. Should only be called from a GameEventListener on the DialogueSystem object.
    public void StartDialogue(DialogueGroup dialogue)
    {
        DisplayDialoguePanel(true);
        AddNewDialogue(dialogue.dialogueLines);
        DisplayNextDialogueMessage();
    }

    private void DisplayDialoguePanel(bool display)
    {
        dialoguePanel.SetActive(display);
    }

    //Displays the next line of dialogue on the screen. Also invoked by the DialoguePanelClick Action, through the DialoguePanelClick script.
    private void DisplayNextDialogueMessage()
    {
        if (dialogueLines.Count <= 0 || dialogueLines == null) return;
        if (isDialogueActive) return;

        textDisplay.text = "";
        StartCoroutine(DisplayTextByEachLetter());
    }

    public IEnumerator DisplayTextByEachLetter()
    {
        if (dialogueLines.Count <= 0 || dialogueLines == null) yield return null;
        isDialogueActive = true;
        PlayDialogueAudio();
        foreach (char letter in dialogueLines[0].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textTimeInterval);
        }

        dialogueLines.RemoveAt(0);
        if (dialogueLines.Count <= 0 || dialogueLines == null)
        {
            yield return new WaitForSeconds(1f);
            DisplayDialoguePanel(false);
            GameEventsQueue.OnEventEnd?.Invoke();
        }
        isDialogueActive = false;
    }

    private void AddNewDialogue(List<string> lines)
    {
        dialogueLines.Clear();
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
    }

    //originally written by Luke
    public void PlayDialogueAudio()
    {
        if (audioClips.Length == 0 || audioClips == null)
        {
            Debug.LogError("Audio clip array is empty!");
            return;
        }

        // Choose a random clip from the array 
        int index = UnityEngine.Random.Range(0, audioClips.Length - 1);
        AudioClip clip = audioClips[index];

        //add audio clip to audio source
        _audioSource.clip = clip;
        // Play the chosen clip
        _audioSource.Play();
    }

    public void StopDialogueAudio()
    {
        _audioSource.Stop();
    }



}