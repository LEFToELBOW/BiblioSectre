using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalGhostMovement : MonoBehaviour
{
    [SerializeField] private float normalGhostSpeed, chasingGhostSpeed, sightRange, ghostChaseTime;
    [SerializeField] private Transform player, ghost;
    [SerializeField] private string ghostType;
    [SerializeField] private GameObject ghostProjectile;
    [SerializeField] private Rigidbody2D ghostProjRb;
    [SerializeField] private Vector3 originalScale, changedScale;
    [SerializeField] private Vector3[] positionList;
    [SerializeField] private Transform castPointN;
    [SerializeField] private Sprite[] spriteArray;
    [SerializeField] private SpriteRenderer spriteRendererVar;

    [SerializeField] private AudioSource GhostLaser;

    private float fireTime, animTime = 0;
    private float interpolationPeriod = .5f;

    private bool projFire;
    private bool isTargeting;
    private Vector2 endPos, moveDirection;
    private int positionIndex = 0;
    private bool targeting, projectileInstantiation, growing, big;

    void Start()
    {
        targeting = false;
        projectileInstantiation = false;
        big = false;
        growing = false;
        Time.timeScale = 1.0f;
        spriteRendererVar.sprite = spriteArray[5];
    }

    // ghost moves along path made up of a list of points (can be inputted manually or use empty gameObjects)
    private void MovePath()
    {

        //transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.deltaTime * normalGhostSpeed);
        transform.position = Vector2.MoveTowards(transform.position, positionList[positionIndex], Time.fixedDeltaTime * normalGhostSpeed);
        moveDirection = (positionList[positionIndex] - transform.position).normalized;
        

        if (transform.position == positionList[positionIndex])
        {
            if (positionIndex == positionList.Length - 1)
            {
                positionIndex = 0;
            }
            else
            {
                positionIndex++;
            }
        }

    }

    // chases player
    private void TargetPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.fixedDeltaTime * chasingGhostSpeed);
        moveDirection = (player.position - transform.position).normalized;
    }

    // detects if player is within line of sight w/ linecast
    private bool CanSeePlayerNS(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(0, 1, 0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (sight.collider != null)
        {
            if (sight.collider.gameObject.CompareTag("Player"))
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

    private bool CanSeePlayerEW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(1, 0, 0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (sight.collider != null)
        {
            if (sight.collider.gameObject.CompareTag("Player"))
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

    private bool CanSeePlayerNESW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(1, 1, 0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (sight.collider != null)
        {
            if (sight.collider.gameObject.CompareTag("Player"))
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

    private bool CanSeePlayerSENW(float distance, Transform castPoint)
    {
        bool seeVal = false;
        float castDist = distance;
        Transform castPointFunc = castPoint;

        Vector2 endPos = castPointFunc.position + new Vector3(-1, 1, 0) * castDist;

        RaycastHit2D sight = Physics2D.Linecast(castPointFunc.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (sight.collider != null)
        {
            if (sight.collider.gameObject.CompareTag("Player"))
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
    IEnumerator PersistentAttack(float chaseTime)
    {
        if (ghostType == "normal")
        {
            AnimateGhostDirection(AnimateGhostLogic());
            TargetPlayer();
        }
        else if (ghostType == "projectile")
        {
            //FireProjectile();
            AnimateGhostDirection(AnimateGhostLogic());
            MovePath();
        }
        else if (ghostType == "grow")
        {  
            AnimateGhostDirection(AnimateGhostLogic());
            TargetPlayer();
            growing = false;
        }
        else
        {
            AnimateGhostDirection(AnimateGhostLogic());
            MovePath();
        }
        yield return new WaitForSeconds(chaseTime);
        targeting = false;
    }

    // launches projectile in random direction when player is detected
    private void Fire()
    {
        GameObject ghostProjIns = Instantiate(ghostProjectile, new Vector2(ghost.transform.position.x, ghost.transform.position.y), Quaternion.identity);

        Rigidbody2D ghostProjRb = ghostProjIns.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = ghostProjIns.GetComponent<CircleCollider2D>();
        Kill kill = ghostProjIns.GetComponent<Kill>();
        LaserColKill projEnd = ghostProjIns.GetComponent<LaserColKill>();
        ghostProjIns.gameObject.layer = LayerMask.NameToLayer("Ghost");
        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        //.Normalize();
        ghostProjIns.gameObject.layer = LayerMask.NameToLayer("wall");   
        ghostProjRb.AddForce(randomVector * 1000);
        GhostLaser.Play();

    
        
    }

    // causes the growing ghost to change size via lerp when player in LOS
    IEnumerator SizeChange(bool growBool)
    {
        if (growBool == true && big == false)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / 3f)
            {
                ghost.transform.localScale = Vector3.Lerp(originalScale, changedScale, t);
                yield return null;
            }
            big = true;
        }
        // when player out of sight range this is triggered (returns ghost to normal size)
        else if (growBool == false && big == true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / 3f)
            {
                ghost.transform.localScale = Vector3.Lerp(changedScale, originalScale, t);
                yield return null;
            }
            big = false;
        }
        else
        {

        }

    }
    // if player in line of sight, target player
    // otherwise remain on pre-set path
    private void DecideToTarget()
    {
        if ((CanSeePlayerNS(sightRange, castPointN) |
            CanSeePlayerNS(-sightRange, castPointN) |
            CanSeePlayerEW(sightRange, castPointN) |
            CanSeePlayerEW(-sightRange, castPointN) |
            CanSeePlayerNESW(sightRange, castPointN) |
            CanSeePlayerNESW(-sightRange, castPointN) |
            CanSeePlayerSENW(sightRange, castPointN) |
            CanSeePlayerSENW(-sightRange, castPointN))
            && targeting)
        {
            isTargeting = true;
            if (ghostType == "normal")
            {
                TargetPlayer();
                AnimateGhostDirection(AnimateGhostLogic());
                
            }
            else if (ghostType == "projectile")
            {
                projFire = true;
                AnimateGhostDirection(AnimateGhostLogic());
            }
            else if (ghostType == "grow")
            {
                TargetPlayer();
                growing = true;
                AnimateGhostDirection(AnimateGhostLogic());
                StartCoroutine(SizeChange(growing));
            }
        }
        
        // invokes chasing coroutine if no longer in LOS but targeting bool is still true
        else if (targeting == true)
        {
            StartCoroutine(PersistentAttack(ghostChaseTime));
            growing = false;
            StartCoroutine(SizeChange(growing));
        }
        else
        {
            MovePath();
            isTargeting = false;
            projFire = false;
        }
    }

    // takes int from ghostdirection and applies that offset to the for loop so that the looping sprites match w/ movement
    private void AnimateGhostDirection(int animDirectionOffset)
    {
        for (int i = 0; i < 4; i++)
        {
            animTime += Time.fixedDeltaTime;
            if (animTime > 0.5f)
            {
                spriteRendererVar.sprite = spriteArray[i + animDirectionOffset];
                animTime = 0f;
            }
            
            if(i == 3)
            {
                for (int j = 3; j > 0; j = j - 1)
                {
                    if (animTime > 0.5f)
                    {
                        spriteRendererVar.sprite = spriteArray[j + animDirectionOffset];
                        animTime = 0f;
                    }
                }
            }
        }
    }

    // based on ghost movement vector, outputs a number corresponding to the 4 directions
    private int AnimateGhostLogic()
    {
        int animDirectionSelect = 0;
        float animDelay = 0f;
        animDelay += Time.fixedDeltaTime;
        
        // reduce switching problems when targeting player
        if (isTargeting == true && animDelay > 2f)
        {
            /*if (moveDirection.x < 0f)
            {
                animDirectionSelect = 8;
                animDelay = 0f;
            }
            else if (moveDirection.x > 0f)
            {
                animDirectionSelect = 12;
                animDelay = 0f;
            }*/
            if (moveDirection.x < 0f && Mathf.Abs(moveDirection.y) < Mathf.Abs(moveDirection.x))
            {
                animDirectionSelect = 8;
            }
            else if (moveDirection.x > 0f && Mathf.Abs(moveDirection.y) < Mathf.Abs(moveDirection.x))
            {
                animDirectionSelect = 12;
            }
            else if (moveDirection.y > 0f && Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
            {
                animDirectionSelect = 0;
            }
            else if (moveDirection.y < 0f && Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
            {
                animDirectionSelect = 4;
            }
            else
            {
                animDirectionSelect = 0;
            }
            animDelay = 0f;
            Debug.Log("Delay done");
        }
        else
        {
            // left
            if (moveDirection.x < 0f && Mathf.Abs(moveDirection.y) < Mathf.Abs(moveDirection.x))
            {
                animDirectionSelect = 8;
            }
            // right
            else if (moveDirection.x > 0f && Mathf.Abs(moveDirection.y) < Mathf.Abs(moveDirection.x))
            {
                animDirectionSelect = 12;
            }
            // moving to bkgd
            else if (moveDirection.y > 0f && Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
            {
                animDirectionSelect = 0;
            }
            // moving to foreground
            else if (moveDirection.y < 0f && Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
            {
                animDirectionSelect = 4;
            }
            else
            {
                animDirectionSelect = 0;
            }
        }

        return animDirectionSelect;
    }
    

    private void FixedUpdate()
    {

        DecideToTarget();
        AnimateGhostDirection(AnimateGhostLogic());
        
        // time delay for projectile ghost to fire when it is targeting player
        if(projFire)
        {
            MovePath();
            fireTime += Time.deltaTime;
            if(fireTime > interpolationPeriod)
            {
                Fire();
                fireTime = 0f;
            }
        }
    }
    
}