using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject spawner; // Reference to the spawner GameObject

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.SetActive(true); // Activate the spawner
        }
    }
}
