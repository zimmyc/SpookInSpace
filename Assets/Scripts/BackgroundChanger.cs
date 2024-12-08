using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public GameObject currentBackground; // The current background
    public GameObject newBackground1; // The first new background
    public GameObject newBackground2;
    public GameObject newBackground3; 
    public GameObject newBackground4;
    public GameObject newBackground5; 
    public GameObject newBackground6; 
    public GameObject newBackground7; 
    public GameObject newBackground8; 
    public GameObject newBackground9; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentBackground.SetActive(false); // Deactivate the current background
            newBackground1.SetActive(true); // Activate the first new background
            newBackground2.SetActive(true);
            newBackground3.SetActive(true);
            newBackground4.SetActive(true);
            newBackground5.SetActive(true);
            newBackground6.SetActive(true);
            newBackground7.SetActive(true);
            newBackground8.SetActive(true);
            newBackground9.SetActive(true);
        }
    }
}