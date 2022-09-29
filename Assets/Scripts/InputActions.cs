using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputActions : MonoBehaviour
{ 
    [SerializeField] private GameObject laser;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;

    [SerializeField] private GameObject RedO;
    [SerializeField] private GameObject BlueO;
    [SerializeField] private GameObject GreenO;


    private TextMesh holdRed, holdBlue, holdGreen;
    
    private PlayerControls input;
    private Vector2 moveDirection = Vector2.zero;


    private Vector2 pos;
    
    private InputAction move;
    private InputAction fire;

    public static bool obtShoot;
    public static bool canShoot;
    private float charges;
    private bool full;
    private string book;
    public static float redBooks, blueBooks, greenBooks;
    public static Vector2 animDirection;


    private void Awake()
    {
        input = new PlayerControls();
        holdRed = RedO.GetComponent<TextMesh>();
        holdBlue = BlueO.GetComponent<TextMesh>();
        holdGreen = GreenO.GetComponent<TextMesh>();

        RedO.SetActive(false);
        BlueO.SetActive(false);
        GreenO.SetActive(false); 
    }

    private void OnEnable()
    {   
        move = input.Player.Move;
        move.Enable();

        fire = input.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        fire = input.Player.Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        animDirection = moveDirection;
        if(!(moveDirection.x == 0 && moveDirection.y == 0))
        {
            if(obtShoot)
            {
                canShoot = true;
            }
            pos = moveDirection;
        }
        else
        {
            if(obtShoot)
            {
                canShoot = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        
    }

    // fire laser
    private void Fire(InputAction.CallbackContext context)
    {    
        if((charges < 1) || !obtShoot || !canShoot)
        { 
            return;
        }
        
        charges--;
        GameObject laserIns = Instantiate(laser, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        LaserColKill laserEnd = laserIns.GetComponent<LaserColKill>();
        
        Rigidbody2D laserRb = laserIns.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = laserIns.GetComponent<CircleCollider2D>();
        laserIns.gameObject.layer = LayerMask.NameToLayer("Laser");

        laserRb.AddForce(pos * 500);
    }

    // collection of books
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(full)
        {
            switch (col.gameObject.tag)
            {
                case "RedShelf":
                    if (book == "Red")
                    {
                        full = false;
                        redBooks++;   
                        RedO.SetActive(false);                   
                    }
                    break;
                case "BlueShelf":
                    if (book == "Blue")
                    {
                        full = false;
                        blueBooks++;
                        BlueO.SetActive(false);
                    }
                    break;
                case "GreenShelf":
                    if (book == "Green")
                    {
                        full = false;
                        greenBooks++;
                        GreenO.SetActive(false);
                    }
                    break;
                case "Laser":
                    charges += 5;
                    obtShoot = true;
                    canShoot = true;
                    Destroy(col.gameObject);
                    Debug.Log(charges);
                    break;
            }
            return;
        }

        switch (col.gameObject.tag)
        {
            case "Red":
                book = "Red";
                full = true;
                Destroy(col.gameObject);
                RedO.SetActive(true);
                break;
            case "Blue":             
                book = "Blue";
                full = true;
                Destroy(col.gameObject);
                BlueO.SetActive(true);
                break;
            case "Green":
                book = "Green";
                full = true;
                Destroy(col.gameObject);
                GreenO.SetActive(true);
                break;
            case "Laser":
                charges += 5;
                obtShoot = true;
                canShoot = true;
                Destroy(col.gameObject);
                break;
        }  
    }

    


}
