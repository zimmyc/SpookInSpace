using UnityEngine;
using UnityEngine.Video;

public class Projectile : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] fireClips; // Array of video clips 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VideoPlayer playerVideo = other.gameObject.GetComponent<VideoPlayer>();
            {
                int randomIndex = Random.Range(0, fireClips.Length); // Get a random index
                playerVideo.clip = fireClips[randomIndex]; // Set the random video clip
                playerVideo.Play();
                playerVideo.loopPointReached += EndReached; // Handle the end of the video
            }
            Invoke("Destroy(gameObject)", 1f);
        }
    }

    void EndReached(VideoPlayer vp)
    {
        vp.Stop(); // This will stop the video when it reaches the end
    }
}