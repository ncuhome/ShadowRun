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
public class CharcterAction : MonoBehaviour,CharacterInputSystem.IGamePlayActions
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
    SpriteRenderer sprite;
    CharacterInputSystem inputActions;
    private float jumpingTime;
    private bool falling;
    private CharacterInputSystem _inputActions;

    private void Awake()
    {
        _inputActions = new CharacterInputSystem();
        _inputActions.GamePlay.SetCallbacks(this); // 将当前对象绑定为回调接收者
    }

    private void OnEnable()
    {
        _inputActions.GamePlay.Enable(); // 启用GamePlay Action Map
    }

    private void OnDisable()
    {
        _inputActions.GamePlay.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        inputActions = new CharacterInputSystem();
        jumpingTime = 0.0f;
        falling = false;
        rb.velocity = new Vector2(1, 0) * fixSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        //GetJumpState();

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

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 moveDir = context.ReadValue<Vector2>();
            sprite.flipX = moveDir.normalized.x < 0 ? true : false;
            rb.velocity = new Vector2(moveDir.normalized.x, 0) * moveForwardSpeed;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            rb.velocity = new Vector2(1, 0) * fixSpeed;
        }
    }
          

    public void OnJump(InputAction.CallbackContext context)
    {
        rb.AddForce(new Vector2(0, 1) * jumpHeight,ForceMode2D.Impulse);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            Debug.Log("fire");
    }
}



