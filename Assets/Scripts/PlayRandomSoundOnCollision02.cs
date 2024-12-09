using UnityEngine;

public class PlayRandomSoundOnCollision02 : MonoBehaviour
{
    public AudioClip[] soundEffects; // Array to hold your sound effects
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            int randomIndex = Random.Range(0, soundEffects.Length);
            audioSource.PlayOneShot(soundEffects[randomIndex]);
            Debug.Log("Sound Effect: " + soundEffects[randomIndex]);
        }
    }
}