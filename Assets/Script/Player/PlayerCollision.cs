using System;
using System.Collections;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HealthManager.health--;
            Debug.Log(HealthManager.health);
            Console.WriteLine(HealthManager.health);
            if (HealthManager.health <= 0)
            {
                Invoke("RestartGame", 0.5f);
            }
            else
            {
                StartCoroutine(getDamage());
            }
        }

    }

    // THIS METHOD FOR INVISIBILITY FOR FEW SECONDS 
    IEnumerator getDamage()
    {
        Physics2D.IgnoreLayerCollision(6, 9);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 9, false);
        Movement.isSprinting = true ;
        yield return new WaitForSeconds(1.2f);
        Movement.isSprinting = false;

    }
}
