using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public int PlayerDeathCount;
    private float time;
    private float grace = 3f;
    private bool invincible;
    void Start()
    {
        PlayerDeathCount = 0;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(invincible)
            {
                Destroy(this.gameObject);
                return;
            }
            col.transform.position = new Vector2(0,-2);
            //Debug.Log(LevelSet.level);
            PlayerDeathCount = PlayerDeathCount + 1;
            Debug.Log(PlayerDeathCount.ToString() + " deaths");
            invincible = true;
            time += Time.deltaTime;
            if (time >= grace)
            {
                time = 0f;
                invincible = false;
            }
        }
    }
}
