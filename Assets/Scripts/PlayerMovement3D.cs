using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public AudioClip walkClip; // Assign your walking audio clip in the Inspector
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    private bool isGrounded;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();

        if (rb2D == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this GameObject. Please add a Rigidbody2D component.");
        }
    }

    void Update()
    {
        if (rb2D != null)
        {
            Vector2 velocity = rb2D.velocity;
            if (isGrounded && Mathf.Abs(velocity.x) > 0.1f && !audioSource.isPlaying)
            {
                audioSource.clip = walkClip;
                audioSource.Play();
            }
            else if (Mathf.Abs(velocity.x) <= 0.1f || !isGrounded)
            {
                audioSource.Stop();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}