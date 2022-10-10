using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;
    [SerializeField] private SpriteRenderer spriteRendererVar;

    private float animTime = 0f;
    private Vector2 moveDirectionAnim;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void AnimatePlayerDirection(int playerDirectionOffset)
    {
        if (moveDirectionAnim.x == 0 && moveDirectionAnim.y == 0)
        {
            spriteRendererVar.sprite = spriteArray[0];
        }
        // movement
        else
        {
            for(int i = 0; i < 4; i++)
            {
                animTime += Time.deltaTime;
                if(animTime > 0.3f)
                {
                    spriteRendererVar.sprite = spriteArray[i + playerDirectionOffset];
                    animTime = 0f;
                }
            }
        }
        // OLD
        /*if (moveDirectionAnim.x == 0 && moveDirectionAnim.y == 0)
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
        }*/    
    }

    private int AnimatePlayerLogic()
    {
        int animDirectionSelect = 0;
        float animDelay = 0f;
        animDelay += Time.deltaTime;

        //D
        if ((-0.25f <= moveDirectionAnim.x) && (0.25f >= moveDirectionAnim.x) && (-0.75f >= moveDirectionAnim.y) && (-1f <= moveDirectionAnim.y))
        {
            animDirectionSelect = 0;
        }
        //U
        else if ((-0.25f <= moveDirectionAnim.x) && (0.25f >= moveDirectionAnim.x) && (0.75f <= moveDirectionAnim.y) && (1f >= moveDirectionAnim.y))
        {
            animDirectionSelect = 20;
        }
        //R
        else if ((-0.25f <= moveDirectionAnim.y) && (0.25f >= moveDirectionAnim.y) && (0.75f <= moveDirectionAnim.x) && (1f >= moveDirectionAnim.x))
        {
            animDirectionSelect = 16;
        }
        //L
        else if ((-0.25f <= moveDirectionAnim.y) && (0.25f >= moveDirectionAnim.y) && (-0.75f >= moveDirectionAnim.x) && (-1f <= moveDirectionAnim.x))
        {
            animDirectionSelect = 12;
        }
        //UL
        else if ((-0.75f < moveDirectionAnim.x) && (-0.25f > moveDirectionAnim.x) && (0.75f > moveDirectionAnim.y) && (0.25f < moveDirectionAnim.y))
        {
            animDirectionSelect = 24;
        }
        //DL
        else if ((-0.75f < moveDirectionAnim.x) && (-0.25f > moveDirectionAnim.x) && (-0.75f < moveDirectionAnim.y) && (-0.25f > moveDirectionAnim.y))
        {
            animDirectionSelect = 4;
        }
        //DR
        else if ((0.75f > moveDirectionAnim.x) && (0.25f < moveDirectionAnim.x) && (-0.75f < moveDirectionAnim.y) && (-0.25f > moveDirectionAnim.y))
        {
            animDirectionSelect = 8;
        }
        //UR
        else if ((0.75f > moveDirectionAnim.x) && (0.25f < moveDirectionAnim.x) && (0.75f > moveDirectionAnim.y) && (0.25f < moveDirectionAnim.y))
        {
            animDirectionSelect = 28;
        }
        else
        {
            animDirectionSelect = 0;
        }
        

        return animDirectionSelect;
    }

    //4 direction
    /*private int AnimatePlayerLogic()
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
    }*/

    // Update is called once per frame
    private void Update()
    {
        moveDirectionAnim = InputActions.animDirection;
        AnimatePlayerDirection(AnimatePlayerLogic());
    }
}
