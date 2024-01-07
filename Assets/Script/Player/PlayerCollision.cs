using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HealthManager.health--;
            Debug.Log("Health: " + HealthManager.health);

            if (HealthManager.health <= 0)
            {
                GameOverScreen.Instance.ShowGameOverScreen(true);
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
    private void RestartGame()
    {
        Debug.Log("Game Restarted");
    }
}
