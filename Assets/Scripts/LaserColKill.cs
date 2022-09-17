using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColKill : MonoBehaviour
{
    private float count;
    private float bounce;
    private void OnCollisionEnter2D(Collision2D col)
    {
        bounce++;
        if(bounce > 2)
            Destroy(this.gameObject);
        if(col.gameObject.tag == "Ghost")
        {
            count++;
            Destroy(col.gameObject);
            Debug.Log("Killed");
        }
    }
}
