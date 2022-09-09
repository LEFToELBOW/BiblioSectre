using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public int PlayerDeathCount;
    void Start()
    {
        PlayerDeathCount = 0;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            LevelSet.level--;
            col.transform.position = new Vector2(0,-22);
            //Debug.Log(LevelSet.level);
            PlayerDeathCount = PlayerDeathCount + 1;
            Debug.Log(PlayerDeathCount.ToString() + " deaths");
        }
    }
}
