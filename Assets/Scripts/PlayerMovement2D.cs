using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public AudioClip walkClip; // Assign your walking audio clip in the Inspector
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    private bool isGrounded;

    void Start()
    {
        // Ensure this script references the correct AudioSource component
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded && Mathf.Abs(rb2D.velocity.x) > 0.1f && !audioSource.isPlaying)
        {
            audioSource.clip = walkClip;
            audioSource.Play();
        }
        else if (Mathf.Abs(rb2D.velocity.x) <= 0.1f || !isGrounded)
        {
            audioSource.Stop();
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