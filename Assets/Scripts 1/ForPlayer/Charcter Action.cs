using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using System.Linq;

/// <summary>
/// 角色移动逻辑
/// 不提供静态
/// </summary>
public class CharcterAction : MonoBehaviour
{
    public Camera mainCamera;
    [Header("角色向前移动速度")]
    public float moveForwardSpeed;
    [Header("角色向后移动速度")]
    public float moveBackSpeed;
    [Header("角色固定移动速度")]
    public float fixSpeed;
    [Header("角色跳跃最大时间")]
    public float jumpMaxTime;
    [Header("角色跳跃力度")]
    public float jumpHeight;


    private Rigidbody2D rb;
    private Collider2D cd;
    Animator ani;
    SpriteRenderer targetRenderer;
    CharacterInputSystem inputActions;
    private float jumpingTime;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();
        targetRenderer = GetComponent<SpriteRenderer>();
        inputActions = new CharacterInputSystem();
        jumpingTime = 0.0f;
        falling = false;
    }


    // Update is called once per frame
    void Update()
    {

        GetMoveState();
        GetJumpState();

    }

   

    private void GetMoveState() 
    {
        //设置移动方向
        float moveX = Input.GetAxis("Horizontal");

        Vector2 moveDir = new Vector2(moveX, 0).normalized;
        rb.velocity = new Vector2(1, 0) * fixSpeed;

        //设置向前和向后的加速度
        if(moveDir.x > 0)
        {
            rb.AddForce(moveDir * (moveForwardSpeed - fixSpeed), ForceMode2D.Impulse);
        }
        else if(moveDir.x < 0)
        {
            rb.AddForce(moveDir * (moveBackSpeed + fixSpeed), ForceMode2D.Impulse);
        }
        

        
        if (rb.velocity.sqrMagnitude > 0.01) ani.SetBool("Move", true);
        else ani.SetBool("Move", false);

        //翻转
        if (rb.velocity.x < 0)
        {
            targetRenderer.flipX = true;
        }
        else
        {
            targetRenderer.flipX = false;
        }

    }

    private void GetJumpState()
    {
        if (OnGround())
        {
            //Debug.Log("on");
            ani.SetTrigger("StopFalling");

            falling = false;
        }
        float jump = Input.GetAxis("Jump");
        if (jump >= 0.1 && !falling)
        {

         
            if(!OnGround())
            {
                jumpingTime += Time.deltaTime;//若在向上跳跃中，增加跳跃计时，不影响坠落
               
                if (jumpingTime >= jumpMaxTime)
                {
                    jumpingTime = 0;
                    falling = true;
                    ani.SetTrigger("Fall");
                    return;
                }
            }

            ani.SetTrigger("Jump");
            rb.AddForce(new Vector2(0.0f, 1) * jumpHeight, ForceMode2D.Impulse);
            
            //Debug.Log(jumpingTime);
        }
        else if (jump <= 0 && (!OnGround()))
        {
            falling = true;
            ani.SetTrigger("Fall");
        }
    }

   

    private bool OnGround()
    {
        return cd.IsTouchingLayers(LayerMask.GetMask("Collider"));
    } 

}



