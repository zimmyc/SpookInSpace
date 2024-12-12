using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                Debug.LogError("VideoPlayer component not found on this GameObject.");
            }
        }
    }

    public void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
    }
}