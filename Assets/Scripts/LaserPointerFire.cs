using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LaserPointerFire : MonoBehaviour
{
    [SerializeField] private float projectileRange, projectileSpeed, hitForce;
    [SerializeField] private Transform fireEnd;
    public GameObject laserProjectile;
    public Rigidbody2D laserRb;

    [SerializeField] private PlayerControls input;
    //private InputAction fire;
    //private bool FireState = false;

    private void OnFire()
    {
        Instantiate(laserProjectile, new Vector2(fireEnd.transform.position.x, fireEnd.transform.position.y), Quaternion.Euler(0,0,90));
        laserRb.velocity = Vector3.right * projectileSpeed;
        Debug.Log("Fired laser!");
    }
    /*private void OnAwake()
    {
        input = new PlayerControls();
        FireState = false;
    }

    private void FixedUpdate()
    {
        fire = input.Player.Fire;
        if(fire.triggered)
        {
            FireState = true;
            Debug.Log("fired");
        }
        /*{
            Instantiate(laserProjectile, new Vector2(fireEnd.transform.position.x, fireEnd.transform.position.y), Quaternion.Euler(0,0,90));
            laserRb.velocity = Vector3.right * projectileSpeed;
            Debug.Log("Fired laser!");
        }
    }*/


}
