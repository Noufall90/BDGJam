using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerLight : MonoBehaviour
{
    public Transform playerTransform;
    public float lightHeightOffset = 2.0f; // Jarak tinggi antara cahaya dan pemain

    private void Update()
    {
        if (playerTransform != null)
        {
            // Mengatur posisi cahaya berdasarkan posisi pemain dengan offset tinggi
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + lightHeightOffset, playerTransform.position.z);

            // Menghadap ke arah pemain
            transform.LookAt(playerTransform);
        }
    }
}
