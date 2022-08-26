using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    
    [SerializeField] private Vector3[] positionList;

    private int positionIndex;

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.deltaTime * moveSpeed);

        if(transform.position == positionList[positionIndex]);

    }

    void Update()
    {
        MoveToTarget();
    }
}
