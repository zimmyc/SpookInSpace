using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown graphicsDropdown;
    public AudioSource audioSource;

    void Start()
    {
        // Initialize volume slider
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Populate the graphics dropdown with quality settings
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(QualitySettings.names.ToList());

        // Set the dropdown to the current quality level
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();

        // Add listener for when the value changes
        graphicsDropdown.onValueChanged.AddListener(SetGraphicsQuality);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false); // Hide options panel
        // Optionally, show the main menu panel if needed
    }
}