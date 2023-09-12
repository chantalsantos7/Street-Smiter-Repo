using StreetSmiterEventSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class FlythroughManager : MonoBehaviour
{
    [SerializeField] MediaItem introVideo;
    [SerializeField] VideoPlayer videoPlayer;

    public void PlayIntroVideo()
    {
        videoPlayer.targetCamera = Camera.main;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.clip = introVideo.clip;
        videoPlayer.Play();
        StartCoroutine(DelayGameStart());
    }

    IEnumerator DelayGameStart()
    {
        yield return new WaitForSeconds((float)introVideo.clip.length);
        videoPlayer.enabled = false;
        GameEventsQueue.OnEventEnd?.Invoke();
    }
}
