using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array to hold multiple spawn points
    public int spawnIndex = 0; // Index to choose the spawn point

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ensure the spawnIndex is within the bounds of the array
            if (spawnIndex >= 0 && spawnIndex < spawnPoints.Length)
            {
                Debug.Log("Teleporting player to: " + spawnPoints[spawnIndex].position);
                other.transform.position = spawnPoints[spawnIndex].position;
            }
            else
            {
                Debug.LogError("Spawn index is out of range!");
            }
        }
    }
}