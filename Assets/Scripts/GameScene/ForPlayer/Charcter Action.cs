using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using System.Linq;


/// <summary>
/// ��ɫ�ƶ��߼�
/// ���ṩ��̬
/// </summary>
public class CharcterAction : MonoBehaviour,CharacterInputSystem.IGamePlayActions
{
    [Header("�ж��Ƿ�Ӵ�����Collider")]
    public Collider2D footCollider;
    private CharacterAction_SO _characterAction_SO;
    public CharacterAction_SO characterAction_SO { 
        get {
            if (!_characterAction_SO)
            {
                _characterAction_SO = Resources.Load("CharacterAction_SO") as CharacterAction_SO;
                if (!_characterAction_SO) Debug.LogError("no characterAction_SO");
            }
            return _characterAction_SO;
        } 
    }
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
        _inputActions.GamePlay.SetCallbacks(this); // ����ǰ�����Ϊ�ص�������
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        jumpingTimer = 0.0f;
    }

    private void OnEnable()
    {
        _inputActions.GamePlay.Enable(); // ����GamePlay Action Map
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
            Debug.Log("move forward");
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
        Debug.Log(jumpState);
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
            Debug.Log("fire");
    }

    IEnumerator OnJumpingState()
    {
        while (jumpState == JumpState.Jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpingTimer += Time.deltaTime;
            if (jumpingTimer >= jumpMaxTime)
            {
                OnFalling();
                Debug.Log("Finish Jump:" + jumpState);
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



