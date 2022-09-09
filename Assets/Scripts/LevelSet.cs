using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    [SerializeField] private GameObject redBook, blueBook, greenBook;
    [SerializeField] private GameObject player;
    public static float level = 1f;
    private GameObject[] books;
    

    private void Start()
    {
        books = new GameObject[3];
        books[0] = redBook;
        books[1] = blueBook;
        books[2] = greenBook;
    }
        
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Player")
        {
            return;
        }
        switch(level)
        {
            case 1:
                Debug.Log("Setting Level");

                player.transform.position = new Vector2(0,-2);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(5, 10)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(15, 20)), Quaternion.identity);
                
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(25, 30)), Quaternion.identity);

                level++;
                break;
            case 2:
                Debug.Log("Going to Level 2");

                player.transform.position = new Vector2(0, 50);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(5, 10)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(5, 10)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(15, 20)), Quaternion.identity);
                
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(25, 30)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(25, 30)), Quaternion.identity);
                
                break;
            case 3:
                break;
        }
    }
    
}
