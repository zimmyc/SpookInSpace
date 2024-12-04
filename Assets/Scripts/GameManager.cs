using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] characters; // Array to hold character prefabs
    private int currentCharacterIndex = 0;

    void Start()
    {
        // Instantiate the first character at the start of the game
        Instantiate(characters[currentCharacterIndex], Vector3.zero, Quaternion.identity);
    }

    public void SwitchCharacter()
    {
        // Destroy the current character
        GameObject currentCharacter = GameObject.FindGameObjectWithTag("Player");
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        // Increment the character index
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;

        // Instantiate the new character
        Instantiate(characters[currentCharacterIndex], Vector3.zero, Quaternion.identity);
    }

    public void LoadNextLevel(string nextSceneName)
    {
        // Switch character before loading the next level
        SwitchCharacter();
        SceneManager.LoadScene(nextSceneName);
    }
}