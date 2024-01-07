using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        // Implementasi logika penyimpanan permainan di sini
        // Contoh: menyimpan data ke PlayerPrefs
        PlayerPrefs.Save();
    }
}
