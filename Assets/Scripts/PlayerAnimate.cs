using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;
    [SerializeField] private SpriteRenderer spriteRendererVar;

    private float animTime = 0f;
    private Vector2 moveDirectionAnim;

    private void AnimatePlayerDirection(int playerDirectionOffset)
    {
        // idle
        if (moveDirectionAnim.x == 0 && moveDirectionAnim.y == 0)
        {
            for(int i = 0; i < 5; i++)
            {
                animTime += Time.deltaTime;
                if(animTime > 0.5f)
                {
                    spriteRendererVar.sprite = spriteArray[i];
                    animTime = 0f;
                }
        
            }
        }
        // movement
        else
        {
            for(int j = 0; j < 6; j++)
            {
                animTime += Time.deltaTime;
                if(animTime > 0.5f)
                {
                    spriteRendererVar.sprite = spriteArray[j + playerDirectionOffset];
                    animTime = 0f;
                }

            }
        }
        
    }

    private int AnimatePlayerLogic()
    {
        int animDirectionSelect = 0;
        float animDelay = 0f;
        animDelay += Time.fixedDeltaTime;

        if (moveDirectionAnim.x < 0f && Mathf.Abs(moveDirectionAnim.y) < Mathf.Abs(moveDirectionAnim.x))
        {
            animDirectionSelect = 5;
        }
        // right
        else if (moveDirectionAnim.x > 0f && Mathf.Abs(moveDirectionAnim.y) < Mathf.Abs(moveDirectionAnim.x))
        {
            animDirectionSelect = 11;
        }
        // moving to bkgd
        else if (moveDirectionAnim.y > 0f && Mathf.Abs(moveDirectionAnim.x) < Mathf.Abs(moveDirectionAnim.y))
        {
            animDirectionSelect = 17;
        }
        // moving to foreground
        else if (moveDirectionAnim.y < 0f && Mathf.Abs(moveDirectionAnim.x) < Mathf.Abs(moveDirectionAnim.y))
        {
            animDirectionSelect = 23;
        }
        else
        {
            animDirectionSelect = 0;
        }

        return animDirectionSelect;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionAnim = InputActions.animDirection;
        AnimatePlayerDirection(AnimatePlayerLogic());
    }
}
