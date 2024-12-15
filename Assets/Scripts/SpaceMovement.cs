using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioClip walkClip; // Assign your walking audio clip in the Inspector
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize SpriteRenderer
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject. Please add an AudioSource component.");
        }
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Flip the sprite based on movement direction
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Play or stop the walking sound based on movement
        if (audioSource != null)
        {
            if (moveInput.magnitude > 0.1f && !audioSource.isPlaying)
            {
                audioSource.clip = walkClip;
                audioSource.Play();
            }
            else if (moveInput.magnitude <= 0.1f && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}