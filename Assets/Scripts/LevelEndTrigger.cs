using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name); // Debug statement
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger"); // Debug statement
            gameManager.LoadNextLevel(nextSceneName);
        }
    }
}