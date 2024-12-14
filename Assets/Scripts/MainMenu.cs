using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;

    void Start()
    {
        optionsPanel.SetActive(false); // Ensure the options panel is hidden at the start

        // Load saved volume setting
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        volumeSlider.value = savedVolume;
        AudioManager.instance.SetVolume(savedVolume);

        // Add listener to the slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Replace "Game" with the name of your game scene
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true); // Show the options panel
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void SetVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
}