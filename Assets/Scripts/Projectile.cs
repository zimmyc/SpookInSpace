using UnityEngine;
using UnityEngine.Video;

public class Projectile : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the video
            videoPlayer.Play();
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}