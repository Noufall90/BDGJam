using UnityEngine;

public class ControlSpotlights : MonoBehaviour
{
    public GameObject[] spotlights; // Array untuk menyimpan semua objek Spotlight2D

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject spotlight in spotlights)
            {
                spotlight.SetActive(!spotlight.activeSelf);
            }
        }
    }
}
