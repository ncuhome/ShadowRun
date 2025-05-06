using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// ��ɫ�ƶ��߼�
/// ���ṩ��̬
/// </summary>
public class CharcterAction : MonoBehaviour,CharacterInputSystem.IGamePlayActions
{
    [Header("判断是否与地面接触Collider")]
    public Collider2D footCollider;

    #region mobile action var
    [Header("虚拟摇杆")]
    public Joystick joystick;
    [Header("虚拟按钮jump")]
    public Button jumpButton;
    private EventTrigger jumpButtonEvent;
    #endregion
    private CharacterAction_SO _characterAction_SO;
    public CharacterAction_SO characterAction_SO { 
        get {
            if (!_characterAction_SO)
            {
                _characterAction_SO = GameConfigManager.instance.characterAction_SO;
                if (!_characterAction_SO) Debug.LogError("no characterAction_SO");
            }
            return _characterAction_SO;
        } 
    }
    #region move base data
    [HideInInspector]
    public float moveForwardSpeed;
    [HideInInspector]
    public float moveBackSpeed;
    [HideInInspector]
    public float fixSpeed;
    [HideInInspector]
    public float jumpMaxTime;
    [HideInInspector]
    public float jumpHeight;  
    [HideInInspector]
    public JumpState jumpState;
    #endregion

    private Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sprite;
    private float jumpingTimer;
    private CharacterInputSystem _inputActions;
    private bool isGround;
    private bool isMove;
    private bool isMoveForward;
    private void Awake()
    {
        _inputActions = new CharacterInputSystem();
        _inputActions.GamePlay.SetCallbacks(this);
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        jumpingTimer = 0.0f;
        #if UNITY_ANDROID || UNITY_IOS
            jumpButtonEvent=jumpButton.GetComponent<EventTrigger>();
        #endif
    }

    private void OnEnable()
    {
        #if UNITY_ANDROID || UNITY_IOS
            jumpButtonInit();
        #else
            _inputActions.GamePlay.Enable(); //enable GamePlay Action Map
        #endif 
    }

    private void OnDisable()
    {
        _inputActions.GamePlay.Disable();
    }

    void Start()
    {
        isGround = false;
        rb.velocity = new Vector2(1, 0) * fixSpeed;
        jumpState = JumpState.NonJump;
        isMove = false;
        UpdateCharacterSO();
    }
    void Update()
    {
        #if UNITY_ANDROID || UNITY_IOS
            JoyStickMove();
        #endif
    }
    private void FixedUpdate()
    {
        UpdateVelocity();
        UpdateCharacterSO();
    }
    private void UpdateCharacterSO(){
        moveForwardSpeed = characterAction_SO.moveForwardSpeed;
        moveBackSpeed = characterAction_SO.moveBackSpeed;
        fixSpeed = characterAction_SO.fixSpeed;
        jumpMaxTime = characterAction_SO.jumpMaxTime;
        jumpHeight = characterAction_SO.jumpHeight;
    }
    private void UpdateVelocity()
    {
        if (!isMove) rb.velocity = new Vector2(fixSpeed, rb.velocity.y);
        else
        {
            if (isMoveForward)
            {
                rb.velocity = new Vector2(moveForwardSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-moveBackSpeed, rb.velocity.y);
            }
            //Debug.Log("isMove");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && collision.IsTouching(footCollider))
        {
            isGround = true;
            jumpState = JumpState.NonJump;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && collision.IsTouching(footCollider))
        {
            isGround = true;
            jumpState = JumpState.NonJump;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && collision.IsTouching(footCollider)) isGround = false;
    }
#if UNITY_ANDROID || UNITY_IOS
    #region mobile action
    private void JoyStickMove()
    {
        Vector2 moveDir = joystick.Direction;
            if (Mathf.Abs(moveDir.x) >= 1f)
            {
                if (moveDir.x >= 0)
                {
                    sprite.flipX = false;
                    isMoveForward = true;
                }
                else
                {
                    sprite.flipX = true;
                    isMoveForward = false;
                }
                isMove = true;
            }
            else
            {
                sprite.flipX = false;
                isMoveForward = false;
                isMove = false;
            }
    }
    private void OnJumpButtonDown()
    {
        jumpButton.image.color=new Color(255,255,255,160);
        if (jumpState == JumpState.Falling) return;
        if (!isGround) return;
            jumpState = JumpState.Jumping;
        StartCoroutine(OnJumpingState());
    }
    private void OnJumpButtonRelease()
    {
        jumpButton.image.color=new Color(255,255,255,100);
        OnFalling();
    }
    private void jumpButtonInit()
    {
            // 按下事件
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((data) => OnJumpButtonDown());
        jumpButtonEvent.triggers.Add(pointerDown);

        // 释放事件
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((data) => OnJumpButtonRelease());
        jumpButtonEvent.triggers.Add(pointerUp);
    }
    #endregion
#endif
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            sprite.flipX = false;
            isMove = false;
            return;
        }
        Vector2 moveDir = context.ReadValue<Vector2>();
        if (moveDir.x >= 0)
        {
            sprite.flipX = false;
            isMoveForward = true;
            //Debug.Log("move forward");
        }
        else
        {
            sprite.flipX = true;
            isMoveForward = false;
        }
        isMove = true;
    }
          

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log(jumpState);
        if (jumpState == JumpState.Falling) return;
        if (context.phase == InputActionPhase.Started )
        {
            if (!isGround) return;
            jumpState = JumpState.Jumping;
        }
        if (context.phase == InputActionPhase.Performed)
        {
            StartCoroutine(OnJumpingState());
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            OnFalling();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ani.SetTrigger("Fire");
        }         
    }

    IEnumerator OnJumpingState()
    {
        float timer=0;
        while (jumpState == JumpState.Jumping)
        {
            timer += Time.deltaTime;
            float jumpTimeLerp = timer/jumpMaxTime; 
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * (1 - jumpTimeLerp));
            jumpingTimer += Time.deltaTime;
            if (jumpingTimer >= jumpMaxTime)
            {
                OnFalling();
                //Debug.Log("Finish Jump:" + jumpState);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    void OnFalling()
    {
        jumpState = JumpState.Falling;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        jumpingTimer = 0f;
    }

   
    public enum JumpState
    {
        NonJump,
        Jumping,
        Falling
    }
}



