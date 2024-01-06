using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lanjut()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Keluar()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene("LevelMenu"); // Menggunakan nama scene "room" untuk memuatnya
}

}
