using UnityEngine;

public class PlayRandomSoundOnCollision : MonoBehaviour
{
    public AudioClip[] soundEffects; // Array to hold your sound effects
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("noise noise noise");
            int randomIndex = Random.Range(0, soundEffects.Length);
            audioSource.PlayOneShot(soundEffects[randomIndex]);
        }
    }
}