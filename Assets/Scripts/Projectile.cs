using UnityEngine;
using UnityEngine.Video;

public class Projectile : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VideoPlayer playerVideo = other.gameObject.GetComponent<VideoPlayer>();
            playerVideo.Play();
            playerVideo.loopPointReached += EndReached; // Add this line to handle the end of the video
            Destroy(gameObject);
        }
    }

    void EndReached(VideoPlayer vp)
    {
        vp.Stop(); // This will stop the video when it reaches the end
    }
}