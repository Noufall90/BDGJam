using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        PlayerPrefs.Save();
    }
}
