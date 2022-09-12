using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public static int PlayerDeathCount;
    [SerializeField] private float grace = 3f;
    private static bool invincible;
    void Start()
    {
        PlayerDeathCount = 0;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(!invincible)
            {
                invincible = true;
                Debug.Log("unkillable");
                col.transform.position = new Vector2(0,-2);
                PlayerDeathCount = PlayerDeathCount + 1;
                Debug.Log(PlayerDeathCount.ToString() + " deaths");
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            StartCoroutine(waitToDestroy());

        }
    }
    private IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(grace);
        invincible = false;
        Debug.Log("no longer unkillable");
    }
}

