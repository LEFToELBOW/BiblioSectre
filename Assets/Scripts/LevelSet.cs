using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSet : MonoBehaviour
{
    [SerializeField] private GameObject redBook, blueBook, greenBook;
    [SerializeField] private GameObject player;
    public static float level = 1f;
    private GameObject[] books;
    public static Vector2 respawn;
    private float totalBooks;

    

    private void Start()
    {
        books = new GameObject[3];
        books[0] = redBook;
        books[1] = blueBook;
        books[2] = greenBook;
    }

    private void Update()
    {
        Debug.Log(level);
        totalBooks = InputActions.redBooks + InputActions.blueBooks + InputActions.greenBooks;
        if(totalBooks == 25 && level == 0)
        {
            level = 2;
            InputActions.redBooks = 0;
            InputActions.blueBooks = 0;
            InputActions.greenBooks = 0;
            totalBooks = 0;
        }
        if(totalBooks == 15 && level == -1)
        {
            level = 3;
            InputActions.redBooks = 0;
            InputActions.blueBooks = 0;
            InputActions.greenBooks = 0;
            totalBooks = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            return;
        }
        switch (level)
        {
            case 1:
                Debug.Log("Setting Level");

                respawn = new Vector2(0, -2);
                player.transform.position = respawn;
                InputActions.canShoot = false;
                InputActions.obtShoot = false;

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12.5f, -8.5f), Random.Range(5.5f, 15)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12.5f, -8.5f), Random.Range(5.5f, 15)), Quaternion.identity);
                
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(8.5f, 12.5f), Random.Range(5.5f, 15)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(8.5f, 12.5f), Random.Range(5.5f, 15)), Quaternion.identity);
               
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 24.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 24.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 24.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 24.5f), Random.Range(5, 17)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-4.5f, 4.9f), Random.Range(15.5f, 19.5f)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-4.5f, 4.9f), Random.Range(15.5f, 19.5f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-0.8f, 3), Random.Range(16, 23)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12f, -3.5f), Random.Range(29, 32)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(6, 12.5f), Random.Range(29, 32)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                
                level = 0;

                break;
            case 2:
                Debug.Log("Going to Level 2");

                respawn = new Vector2(0, 50);
                player.transform.position = respawn;
                InputActions.canShoot = false;
                InputActions.obtShoot = false;

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(19.5f, 25), Random.Range(47.5f, 54.3f)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(19.5f, 25), Random.Range(47.5f, 54.3f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(25, 34), Random.Range(57.5f, 61.5f)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(25, 34), Random.Range(57.5f, 61.5f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-25.5f, -19), Random.Range(47.7f, 53.7f)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-25.5f, -19), Random.Range(47.7f, 53.7f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-33.5f, -26.5f), Random.Range(59.5f, 61.5f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12.5f, 11.5f), Random.Range(63.7f, 65)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12.5f, 11.5f), Random.Range(63.7f, 65)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12.5f, 11.5f), Random.Range(63.7f, 65)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(16, 25), Random.Range(75.2f, 92)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(16, 25), Random.Range(75.2f, 92)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(16, 25), Random.Range(75.2f, 92)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-21, -16), Random.Range(75.2f, 92)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-21, -16), Random.Range(75.2f, 92)), Quaternion.identity);

                level = -1;

                break;
            case 3:


                break;
        }
    }
}
