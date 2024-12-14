using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnTrigger : MonoBehaviour
{
    public GameObject pauseCanvas; // Assign your Canvas in the Inspector

    void Start()
    {
        pauseCanvas.SetActive(false); // Ensure the Canvas is initially hidden
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            Pause();
        }
    }

    void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0; // Pauses the game
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1; // Resumes the game
    }
}