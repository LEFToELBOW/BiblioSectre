using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    public GameObject redBook, blueBook, greenBook;
    private float level = 1f;

    private void start()
    {
        redBook = GameObject.Find("Red Book");
        blueBook = GameObject.Find("Blue Book");
        greenBook = GameObject.Find("Green Book");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(level)
        {
            case 1:
                Instantiate(redBook, new Vector2(0,0), Quaternion.identity);
                break;
        }
    }
    
}
