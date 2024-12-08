using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array to hold multiple spawn points
    public int initialSpawnIndex = 0; // Index to choose the initial spawn point
    public GameObject[] characters; // Array to hold character prefabs
    public Camera mainCamera; // Reference to the main camera

    private GameObject currentCharacter; // Reference to the current character

    void Start()
    {
        // Instantiate the initial character at the initial spawn point
        currentCharacter = Instantiate(characters[0], spawnPoints[initialSpawnIndex].position, Quaternion.identity);
        mainCamera.transform.position = new Vector3(spawnPoints[initialSpawnIndex].position.x, spawnPoints[initialSpawnIndex].position.y, mainCamera.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ensure the spawnIndex is within the bounds of the array
            if (initialSpawnIndex >= 0 && initialSpawnIndex < spawnPoints.Length)
            {
                Vector3 spawnPosition = spawnPoints[initialSpawnIndex].position;
                Debug.Log("Teleporting player to: " + spawnPosition);

                // Destroy the current character
                Destroy(currentCharacter);

                // Instantiate the new character at the spawn point
                currentCharacter = Instantiate(characters[initialSpawnIndex], spawnPosition, Quaternion.identity);

                // Move the camera to the new position
                mainCamera.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, mainCamera.transform.position.z);
            }
            else
            {
                Debug.LogError("Spawn index is out of range!");
            }
        }
    }
}