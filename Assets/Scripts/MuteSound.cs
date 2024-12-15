using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public AudioClip soundToMute; // The sound clip you want to mute
    private AudioSource audioSource; // Reference to the Audio Source component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    void Update()
    {
        if (audioSource.clip == soundToMute)
        {
            audioSource.mute = true; // Mute the sound
        }
        else
        {
            audioSource.mute = false; // Unmute other sounds
        }
    }
}