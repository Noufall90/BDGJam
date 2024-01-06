using UnityEngine;

public class ControlSpotlights : MonoBehaviour
{
    public GameObject[] spotlights; // Array untuk menyimpan semua objek Spotlight2D

    void Update()
    {
        // Cek jika tombol 'E' ditekan
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Loop melalui setiap spotlight dalam array dan hidupkan/matiakan sesuai dengan status saat ini
            foreach (GameObject spotlight in spotlights)
            {
                spotlight.SetActive(!spotlight.activeSelf);
            }
        }
    }
}
