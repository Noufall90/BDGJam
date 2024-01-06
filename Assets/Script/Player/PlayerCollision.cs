using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == ""){
            HealthManager.health--;
            if (HealthManager.health <= 0 )
            {
                Invoke("RestartGame", 2.5f);
            }else{
                
            }
        }
    }

    // THIS METHOD FOR INVISIBILITY FOR FEW SECONDS 
    IEnumerator getDamage(){
        Physics2D.IgnoreLayerCollision(6,8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6,8, false);
    }
}
