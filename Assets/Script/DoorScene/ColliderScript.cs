using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderScript : MonoBehaviour
{
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}