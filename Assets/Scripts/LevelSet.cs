using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    [SerializeField] private GameObject redBook, blueBook, greenBook;
    [SerializeField] private GameObject player;
    private float level = 1f;
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
        switch(level)
        {
            case 1:
                Debug.Log(books.Length);

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

                
                Debug.Log("Something is happenning");
                level++;
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    
}
