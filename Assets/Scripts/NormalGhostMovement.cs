using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    
    [SerializeField] private Vector3[] positionList;

    private int positionIndex = 0;

    void MovePath()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.deltaTime * moveSpeed);

        if(transform.position == positionList[positionIndex])
        {
            if(positionIndex == positionList.Length - 1)
            {
                positionIndex = 0;
            }
            else
            {
                positionIndex++;
            }
        }

    }

    void TargetPlayer()
    {
        
    }

    void Update()
    {
        MovePath();
    }
}
