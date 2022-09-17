using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    [SerializeField] private GameObject redBook, blueBook, greenBook;
    [SerializeField] private GameObject player;
    public static float level = 1f;
    private GameObject[] books;
    public static Vector2 respawn;

    

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
                
                respawn = new Vector2(0,-2);
                player.transform.position = respawn;
                InputActions.canShoot = false;
                InputActions.obtShoot = false;
                LightDim.dim = 5;

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

                respawn = new Vector2(0, 50);
                player.transform.position = respawn;
                InputActions.canShoot = false;
                InputActions.obtShoot = false;
                LightDim.dim = 1;

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-5,-1.8f), Random.Range(63, 70)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-5, -1.8f), Random.Range(72, 80)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(2, 5), Random.Range(63, 70)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(2, 5), Random.Range(72, 80)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(20, 25), Random.Range(46, 55)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(33, 36), Random.Range(46, 55)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-24.5f, -18.5f), Random.Range(46, 55)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-32, -36), Random.Range(46, 55)), Quaternion.identity);
                
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-18, -13), Random.Range(80, 89)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(-18, -13), Random.Range(80, 89)), Quaternion.identity);

                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(13, 18), Random.Range(80, 89)), Quaternion.identity);
                Instantiate(books[Random.Range(0,3)], new Vector2(Random.Range(13, 18), Random.Range(80, 89)), Quaternion.identity);
                
                break;
            case 3:
                break;
        }
    }
    
}
