using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spotlights; // Array untuk menyimpan semua objek Spotlight2D
    public float chaseDistanceWithSpotlight;
    public float chaseDistanceWithoutSpotlight;
    public float speed;
    public AudioClip chaseSoundClip; // Audio yang ingin digunakan untuk looping

    private AudioSource audioSource;

    void Start()
    {
        // Menginisialisasi AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = chaseSoundClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false; // Tidak memainkan audio saat permainan dimulai
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        bool spotlightActive = IsAnySpotlightActive();

        if (spotlightActive && distance < chaseDistanceWithSpotlight)
        {
            ChasePlayer();
            PlayChaseSound();
        }
        else if (!spotlightActive && distance < chaseDistanceWithoutSpotlight)
        {
            ChasePlayer();
            PlayChaseSound();
        }
        else
        {
            StopChaseSound();
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

    void PlayChaseSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopChaseSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
