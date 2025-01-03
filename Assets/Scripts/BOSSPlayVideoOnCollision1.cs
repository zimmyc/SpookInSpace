using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BOSSPlayVideoOnCollision : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public VideoClip[] videoClips; // Array of video clips

    void Start()
    {
        // Ensure the video player is not playing at the start
        videoPlayer.Stop();
        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayRandomVideo();
            Debug.Log("collided with boss");
        }
    }

    void PlayRandomVideo()
    {
        if (videoClips.Length > 0)
        {
            int randomIndex = Random.Range(0, videoClips.Length);
            videoPlayer.clip = videoClips[randomIndex];
            videoPlayer.Play();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Stop the video and perform any other actions needed
        vp.Stop();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart
        Debug.Log("hit the boss so restarting");
    }
}