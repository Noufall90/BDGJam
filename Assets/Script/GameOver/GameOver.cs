using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen Instance; // Singleton instance

    private void Awake()
    {
        // Ensure only one instance of the GameOverScreen exists
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(false); // Initially hide the GameOverScreen
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOverScreen(bool show)
    {
        gameObject.SetActive(show);
    }
}

