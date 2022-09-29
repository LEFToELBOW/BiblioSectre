using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    //public static int PlayerDeathCount;

    void Start()
    {
        //PlayerDeathCount = 0;
    }
    private static bool invincible = false;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(invincible == false)
            {
                //invincible = true;
                Debug.Log(invincible);
                
                col.transform.position = LevelSet.respawn;
                
                InputActions.playerDeathCount++;
                //Debug.Log(PlayerDeathCount.ToString() + " deaths");
                
                //StartCoroutine(waitToStop());
            }
            else
            {
                //Destroy(this.gameObject); 
                invincible = false;
                //PlayerDeathCount++;
            }             
        }
    }
    private IEnumerator waitToStop()
    {
        yield return new WaitForSeconds(1);
        invincible = false;
        Debug.Log(invincible);
    }
}

