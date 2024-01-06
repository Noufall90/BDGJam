using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spotlights; // Array untuk menyimpan semua objek Spotlight2D
    public float chaseDistanceWithSpotlight;
    public float chaseDistanceWithoutSpotlight;
    public float speed;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        bool spotlightActive = IsAnySpotlightActive();

        if (spotlightActive && distance < chaseDistanceWithSpotlight)
        {
            ChasePlayer();
        }
        else if (!spotlightActive && distance < chaseDistanceWithoutSpotlight)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    bool IsAnySpotlightActive()
    {
        foreach (GameObject spotlight in spotlights)
        {
            if (spotlight.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
