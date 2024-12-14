using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Press 'Q' to load the MenuScreen scene
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
}