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
    public static float gameEndTime;

    [SerializeField] private GameObject Holding;
    private TextMesh hold;

    [SerializeField] private GameObject red, blue, green;

    

    private void Start()
    {
        hold = Holding.GetComponent<TextMesh>();
        books = new GameObject[3];
        books[0] = redBook;
        books[1] = blueBook;
        books[2] = greenBook;
        
    }

    private void Update()
    {
        totalBooks = InputActions.redBooks + InputActions.blueBooks + InputActions.greenBooks;
        if(totalBooks == 17 && level == 0)
        {
            level = 2;
            InputActions.redBooks = 0;
            InputActions.blueBooks = 0;
            InputActions.greenBooks = 0;
            totalBooks = 0;
            hold.text = "Advance to Next Level";
            red.SetActive(false);
            blue.SetActive(false);
            green.SetActive(false);
        }
        if(totalBooks == 15 && level == -1)
        {
            gameEndTime = Timer.timeRemaining;
            Timer.timerIsRunning = false; 
            InputActions.redBooks = 0;
            InputActions.blueBooks = 0;
            InputActions.greenBooks = 0;
            totalBooks = 0;

            SceneManager.LoadScene("winScreen");
            Timer.timeRemaining = 480;
            level = 1;
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
                Timer.timerIsRunning = true; 
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

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.5f, -17.5f), Random.Range(5, 17)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-4.5f, 4.9f), Random.Range(15.5f, 19.5f)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-4.5f, 4.9f), Random.Range(15.5f, 19.5f)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-0.8f, 3), Random.Range(16, 23)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-12f, -3.5f), Random.Range(29, 32)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(6, 12.5f), Random.Range(29, 32)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(-24.8f, -17.5f), Random.Range(20.5f, 38)), Quaternion.identity);

                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                Instantiate(books[Random.Range(0, 3)], new Vector2(Random.Range(17.5f, 23), Random.Range(20.5f, 38)), Quaternion.identity);
                
                level = 0;

                break;
            case 2:
                hold.text = "Holding: ";
                
                red.SetActive(true);
                blue.SetActive(true);
                green.SetActive(true);

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
