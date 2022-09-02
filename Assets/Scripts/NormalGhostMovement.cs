using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float ghostSpeed = 2f;
    [SerializeField] private float sightRange = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform castPointLTop, castPointLBottom,castPointRTop, castPointRBottom;
    [SerializeField] private Vector3[] positionList;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private bool targeting;
    [SerializeField] private float playerDistance;

    private int positionIndex = 2;

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

    // detects if player is within line of sight w/ linecast
    bool CanSeePlayerL(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = -distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + Vector3.right * castDist;
        
        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        //if !=null, then linecast hit an object in the action layer (environment i.e. bookshelves or player)
        //if tag of detected obj in layer == player, then follow
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
            Debug.DrawLine(castPointFunc.position, endPos, Color.red);       
        }
        return seeVal;
    }

    bool CanSeePlayerR(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + Vector3.right * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

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
            Debug.DrawLine(castPointFunc.position, endPos, Color.blue);
        }
        return seeVal;
    }
    
    // if player in line of sight, target player
    // otherwise remain on pre-set path
    void DecideToTarget()
    {
        if(CanSeePlayerL(sightRange, castPointLTop) | CanSeePlayerL(sightRange, castPointLBottom) | CanSeePlayerR(sightRange, castPointRTop) | CanSeePlayerR(sightRange, castPointRBottom))
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
