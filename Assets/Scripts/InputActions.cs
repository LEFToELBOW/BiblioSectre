using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{ 
    [SerializeField] private GameObject laser;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;

    private PlayerControls input;
    private Vector2 moveDirection = Vector2.zero;


    private Vector2 pos;
    
    private InputAction move;
    private InputAction fire;

    private bool obtShoot;
    private bool canShoot;
    private float charges = 15;
    private bool full;
    private string book;
    private float redBooks;
    private float blueBooks;
    private float greenBooks;


    private void Awake()
    {
        input = new PlayerControls();
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

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if(!(moveDirection.x == 0 && moveDirection.y == 0))
        {
            if(obtShoot)
            {
                canShoot = true;
            }
            pos = moveDirection;
            Debug.Log(pos);
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

    private void Fire(InputAction.CallbackContext context)
    {    
        if((charges < 1) || !obtShoot || !canShoot)
        { 
            return;
        }
        
        charges--;

        GameObject laserIns = Instantiate(laser, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Rigidbody2D laserRb = laserIns.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = laserIns.GetComponent<CircleCollider2D>();
        laserIns.gameObject.layer = LayerMask.NameToLayer("Laser");

        laserRb.AddForce(pos * 500);
    }

    private void OnCollisionEnter2D(Collision2D col)
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
                        Debug.Log(redBooks);                     
                    }
                    break;
                case "BlueShelf":
                    if (book == "Blue")
                    {
                        full = false;
                        blueBooks++;
                        Debug.Log(blueBooks);
                    }
                    break;
                case "GreenShelf":
                    if (book == "Green")
                    {
                        full = false;
                        greenBooks++;
                        Debug.Log(greenBooks);
                    }
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
                break;
            case "Blue":             
                book = "Blue";
                full = true;
                Destroy(col.gameObject);
                break;
            case "Green":
                book = "Green";
                full = true;
                Destroy(col.gameObject);
                break;
            case "Laser":
                obtShoot = true;
                canShoot = true;
                Destroy(col.gameObject);
                break;
        }  
    }



    


}
