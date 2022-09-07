using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float normalGhostSpeed = 2f;
    [SerializeField] private float chasingGhostSpeed = 3f;
    [SerializeField] private float sightRange = 3f;
    [SerializeField] private float ghostChaseTime = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3[] positionList;
    [SerializeField] private Transform castPointN, castPointNE, castPointE, castPointSE, castPointS, castPointSW, castPointW, castPointNW;
    
    private Vector2 endPos;
    private int positionIndex = 0;
    private bool targeting;

    void Start()
    {
        targeting = false;
    }

    // ghost moves along path made up of a list of points (can be inputted manually or use empty gameObjects)
    void MovePath()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.deltaTime * normalGhostSpeed);

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
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * chasingGhostSpeed);
    }

    // detects if player is within line of sight w/ linecast
    bool CanSeePlayerNS(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(0,1,0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
                targeting = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointFunc.position, endPos, Color.blue);
        }
        return seeVal;
    }
    
    bool CanSeePlayerEW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(1,0,0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
                targeting = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointFunc.position, endPos, Color.blue);
        }
        return seeVal;
    }

    bool CanSeePlayerNESW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(1,1,0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
                targeting = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointFunc.position, endPos, Color.blue);
        }
        return seeVal;
    }

    bool CanSeePlayerSENW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(-1,1,0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if(sight.collider != null)
        {
            if(sight.collider.gameObject.CompareTag("Player"))
            {
                seeVal = true;
                targeting = true;
            }
            else
            {
                seeVal = false;
            }
            Debug.DrawLine(castPointFunc.position, endPos, Color.blue);
        }
        return seeVal;
    }
    
    // coroutine makes the ghost continue following the player for a certain amt of time after leaving line of sight before going back to path
    IEnumerator Wait(float chaseTime)
    {
        TargetPlayer();
        yield return new WaitForSeconds(chaseTime);
        targeting = false;
    }

    // if player in line of sight, target player
    // otherwise remain on pre-set path
    void DecideToTarget()
    {
        if((CanSeePlayerNS(sightRange, castPointN) | CanSeePlayerNS(-sightRange, castPointS) | CanSeePlayerEW(sightRange, castPointE) | CanSeePlayerEW(-sightRange, castPointW) | CanSeePlayerNESW(sightRange, castPointNE) | CanSeePlayerNESW(-sightRange, castPointSW) | CanSeePlayerSENW(sightRange, castPointNW) | CanSeePlayerSENW(-sightRange, castPointSE)) && targeting)
        {
            TargetPlayer();
        }
        // invokes chasing coroutine if no longer in LOS but targeting bool is still true
        else if(targeting == true)
        {
            StartCoroutine(Wait(ghostChaseTime));   
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
