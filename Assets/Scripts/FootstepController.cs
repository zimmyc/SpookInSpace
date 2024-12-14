using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip footstepSound; // Single footstep sound clip
    public float stepInterval = 0.5f; // Time interval between steps
    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isGrounded; // Check if the player is on the ground
    private float stepTimer; // Timer to track time between steps

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    void Update()
    {
        CheckGrounded(); // Check if the player is on the ground

        if (IsWalking() && isGrounded)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // Reset the step timer
            }
        }
        else
        {
            stepTimer = 0f; // Reset the step timer when not walking or grounded
            StopFootstepSound();
        }
    }

    void CheckGrounded()
    {
        // Use a raycast to check if the player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        isGrounded = hit.collider != null;
        Debug.Log("Is Grounded: " + isGrounded);
    }

    bool IsWalking()
    {
        // Replace this with your own logic to determine if the player is walking
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }

    void StopFootstepSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}