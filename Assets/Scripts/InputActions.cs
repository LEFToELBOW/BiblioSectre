using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{ 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    [Space]
    public PlayerControls input;
    private Vector2 moveDirection = Vector2.zero;
    public InputAction move;


    private void Awake()
    {
        input = new PlayerControls();
    }
    private void OnEnable()
    {   
        move = input.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }


}
