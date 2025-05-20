using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerState { Walk, Run, Jump }

    private PlayerState currentState = PlayerState.Walk;
    private PlayerState previousState = PlayerState.Walk; // 상태 변화 감지용

    public float maxSpeed = 5f;
    public float runSpeedMultiplier = 2f;
    public float jumpPower = 10f;

    private float originalMaxSpeed;

    public int jumpCount = 0;
    public int maxJumpCount = 2;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalMaxSpeed = maxSpeed;
    }

    void Update()
    {
        HandleStateChange();
        LogStateChange(); // 상태가 바뀌었을 때 콘솔 출력
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleStateChange()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            currentState = PlayerState.Jump;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentState = PlayerState.Run;
        }
        else
        {
            currentState = PlayerState.Walk;
        }
    }

    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float speed = currentState switch
        {
            PlayerState.Walk => originalMaxSpeed,
            PlayerState.Run => originalMaxSpeed * runSpeedMultiplier,
            PlayerState.Jump => maxSpeed,
            _ => originalMaxSpeed
        };

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.linearVelocity.x > speed)
            rigid.linearVelocity = new Vector2(speed, rigid.linearVelocity.y);
        else if (rigid.linearVelocity.x < -speed)
            rigid.linearVelocity = new Vector2(-speed, rigid.linearVelocity.y);
    }

    void LogStateChange()
    {
        if (currentState != previousState)
        {
            Debug.Log("현재 상태: " + currentState.ToString());
            previousState = currentState;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("PlatformObj"))
        {
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("게임 오버");
            jumpCount = 0;
        }
    }
}