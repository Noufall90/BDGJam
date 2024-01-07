using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameObject gameOverCanvas;
    private bool isDead = false;
    private void Awake()
    {
        // Find the canvas with the "GameOver" tag
        gameOverCanvas = GameObject.FindWithTag("GameOver");

        // Disable the game over canvas if found
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HealthManager.health--;
            Debug.Log("Health: " + HealthManager.health);

            if (HealthManager.health <= 0)
            {
                isDead = true;
                ShowGameOverCanvas();
            }
            else
            {
                StartCoroutine(GetDamageRoutine());
            }
        }
    }

    IEnumerator GetDamageRoutine()
    {
        Physics2D.IgnoreLayerCollision(6, 9, true);
        Movement.isSprinting = true;
        yield return new WaitForSeconds(3f);

        Physics2D.IgnoreLayerCollision(6, 9, false);
        Movement.isSprinting = false;
    }

    // Metode untuk me-restart game
    public void RestartGame()
    {
        // Get the current scene index

        isDead = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene to restart the game
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void ShowGameOverCanvas()
    {
        // Enable the game over canvas if found
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // You can add any additional logic here when the player dies
    }
    public void Quit()
    {
#if UNITY_EDITOR
        // If in the Unity Editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If not in the Unity Editor, quit the application
        Application.Quit();
#endif
    }

}
