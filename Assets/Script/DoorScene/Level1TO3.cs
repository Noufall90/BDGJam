using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1TO3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Credits"); // Ganti "RuangTamu" dengan nama scene yang ingin Anda tuju
        }
    }
}
