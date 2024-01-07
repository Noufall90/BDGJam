using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1TO2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2"); // Ganti "RuangTamu" dengan nama scene yang ingin Anda tuju
        }
    }
}
