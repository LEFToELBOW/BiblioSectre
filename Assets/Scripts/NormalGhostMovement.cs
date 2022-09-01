using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float ghostSpeed = 2f;
    [SerializeField] private float sightRange = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform castPointL, castPointR;
    [SerializeField] private Vector3[] positionList;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private bool targeting;
    [SerializeField] private float playerDistance;

    private int positionIndex = 2;
    
    void OnSceneLoad()
    {
        
    }

    // ghost moves along path made up of a list of points (can be inputted manually or use empty gameObjects)
    void MovePath()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.deltaTime * ghostSpeed);

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
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * ghostSpeed);
    }

    // detects if player is within line of sight
    bool CanSeePlayerL(float distance)
    {
        bool seeVal = false;
        float castDist = -distance;

        Vector2 endPos = castPointL.position + Vector3.right * castDist;
        
        //RaycastHit2D sight = Physics2D.CircleCast(castPointL.position, 3f, endPos, 1 << LayerMask.NameToLayer("Action"));
        RaycastHit2D sight = Physics2D.Linecast(castPointL.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointL.position, endPos, Color.red);       
        }
        return seeVal;
    }
     

    bool CanSeePlayerR(float distance)
    {
        bool seeVal = false;
        float castDist = distance;

        Vector2 endPos = castPointR.position + Vector3.right * castDist;

        //RaycastHit2D sight = Physics2D.CircleCast(castPointL.position, 3f, endPos, 1 << LayerMask.NameToLayer("Action"));
        RaycastHit2D sight = Physics2D.Linecast(castPointR.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointL.position, endPos, Color.blue);
        }
        return seeVal;
    }
    
    // if player in line of sight, target player
    // otherwise remain on pre-set path
    void DecideToTarget()
    {
        if(CanSeePlayerL(sightRange) | CanSeePlayerR(sightRange))
        {
            Debug.Log("in sight");
            TargetPlayer();
        }
        else
        {
            MovePath();
        }
    }

    void Update()
    {
        DecideToTarget();
    }
}
