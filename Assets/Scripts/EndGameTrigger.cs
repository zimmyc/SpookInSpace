using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    public string mainMenuSceneName = "MenuScreen"; // Name of the main menu scene
    public CanvasGroup endGameCanvasGroup; // Reference to the Canvas Group for fading
    public TMP_Text endGameTitle; // Reference to the TextMeshProUGUI element
    private AudioSource[] allAudioSources; // Array to hold all audio sources

    void Start()
    {
        if (endGameCanvasGroup != null)
        {
            endGameCanvasGroup.alpha = 0; // Ensure the canvas is hidden at the start
            endGameCanvasGroup.gameObject.SetActive(false);
        }

        // Find all audio sources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered by: " + other.name); // Log the name of the colliding object

        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            Debug.Log("Player entered the trigger zone."); // Log when the player enters the trigger
            if (endGameCanvasGroup != null)
            {
                endGameCanvasGroup.gameObject.SetActive(true); // Show the end game canvas
                Time.timeScale = 0; // Pause the game
                MuteAllAudio(); // Mute all audio
                StartCoroutine(SimplifiedEndGameSequence());
            }
        }
    }

    void MuteAllAudio()
    {
        AudioListener.pause = true; // Mute all audio
    }

    void UnmuteAllAudio()
    {
        AudioListener.pause = false; // Unmute all audio
    }

    IEnumerator SimplifiedEndGameSequence()
    {
        Debug.Log("Starting simplified end game sequence."); // Log the start of the sequence
        yield return new WaitForSecondsRealtime(2f); // Wait for 2 seconds in real time
        Debug.Log("Loading main menu scene: " + mainMenuSceneName); // Log before loading the main menu scene
        Time.timeScale = 1; // Resume the game before loading the main menu
        UnmuteAllAudio(); // Unmute all audio
        SceneManager.LoadScene(mainMenuSceneName); // Load the main menu scene
    }
}