using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LaserPointerFire : MonoBehaviour
{
    [SerializeField] private float projectileRange, hitForce;
    [SerializeField] private Transform fireEnd;
    public GameObject laserProjectile;

    private void OnFire()
    {
        Debug.Log("Fired laser!");
    }


}
