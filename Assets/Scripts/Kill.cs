using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            LevelSet.level--;
            col.transform.position = new Vector2(0,-22);
            Debug.Log(LevelSet.level);
        }
    }
}
