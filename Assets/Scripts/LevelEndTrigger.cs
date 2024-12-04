using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public ScreenFader screenFader;
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger"); // Debug statement
            screenFader.FadeToNextLevel(nextSceneName);
        }
    }
}