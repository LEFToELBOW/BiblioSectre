using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    [SerializeField] private GameObject redBook, blueBook, greenBook;
    private float level = 1f;
    public GameObject[] books;

    private void Start()
    {

        books = new GameObject[3];
        books[0] = redBook;
        books[1] = blueBook;
        books[2] = greenBook;
    }
        
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(level)
        {
            case 1:
                Debug.Log(books.Length);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(10, 15)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(10, 15)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(10, 15)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(10, 15)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(15, 20)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(15, 20)), Quaternion.identity);
                
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-20, -17), Random.Range(20, 25)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(17, 20), Random.Range(20, 25)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-12, -8), Random.Range(20, 25)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(8, 12), Random.Range(20, 25)), Quaternion.identity);

                
                Debug.Log("Something is happenning");
                level++;
                break;
        }
    }
    
}
