using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "MediaPlayer", menuName = "ScriptableObjects/MediaPlayer")]
public class MediaPlayer : ScriptableObject
{
    [HideInInspector] public VideoPlayer videoPlayer = new VideoPlayer();

    public void PlayClipOnCamera(VideoClip clip, Camera camera)
    {
        videoPlayer.targetCamera = camera;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    public void DisableCamera()
    {

    }
}
