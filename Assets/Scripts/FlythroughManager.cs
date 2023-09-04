using StreetSmiterEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FlythroughManager : MonoBehaviour
{
    [SerializeField] MediaItem introVideo;
    [SerializeField] VideoPlayer videoPlayer;

    public void PlayIntroVideo()
    {
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.Play();
        StartCoroutine(DelayGameStart());
    }

    IEnumerator DelayGameStart()
    {
        yield return new WaitForSeconds((float)introVideo.clip.length);
        GameEventsQueue.OnEventEnd?.Invoke();
    }
}
