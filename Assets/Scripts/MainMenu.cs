using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;

    void Start()
    {
        optionsPanel.SetActive(false); // Ensure the options panel is hidden at the start
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Replace "GameScene" with the name of your game scene
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true); // Show the options panel
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}