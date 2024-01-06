using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceThreshold;
    private float distance;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceThreshold)
        {
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
            Atau jika ingin menghentikan pergerakan, gunakan speed = 0;
            speed = 0;
        }
    }
}
