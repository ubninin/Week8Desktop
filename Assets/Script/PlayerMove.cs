using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerState { Walk, Run, Jump }

    private PlayerState currentState = PlayerState.Walk;
    private PlayerState previousState = PlayerState.Walk;

    public float maxSpeed = 5f;
    public float runSpeedMultiplier = 2f;
    public float jumpPower = 10f;

    private float originalMaxSpeed;

    public int jumpCount = 0;
    public int maxJumpCount = 2;

    private Rigidbody2D rigid;

    private float moveInput = 0f;
    private bool jumpRequested = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalMaxSpeed = maxSpeed;

        // 충돌 감지 정확도 향상
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            jumpRequested = true;
        }

        HandleStateChange();
        LogStateChange();
    }

    void FixedUpdate()
    {
        HandleJump();
        HandleMovement();
    }

    void HandleStateChange()
    {
        if (jumpRequested)
        {
            currentState = PlayerState.Jump;
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

    void HandleJump()
    {
        if (jumpRequested)
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
            jumpRequested = false;
        }
    }

    void HandleMovement()
    {
        float speed = currentState switch
        {
            PlayerState.Walk => originalMaxSpeed,
            PlayerState.Run => originalMaxSpeed * runSpeedMultiplier,
            PlayerState.Jump => originalMaxSpeed,
            _ => originalMaxSpeed
        };

        rigid.linearVelocity = new Vector2(moveInput * speed, rigid.linearVelocity.y);
    }

    void LogStateChange()
    {
        if (currentState != previousState)
        {
            previousState = currentState;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") ||
            collision.gameObject.CompareTag("PlatformObj") ||
            collision.gameObject.CompareTag("Water"))
        {
            if (collision.gameObject.CompareTag("Water"))
                Debug.Log("game over (water)");

            jumpCount = 0;
        }
    }

    //  겹쳤을 때 위로 밀기
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformObj"))
        {
            if (collision.contactCount > 0)
            {
                ContactPoint2D contact = collision.GetContact(0);
                Vector2 penetrationDir = contact.normal;

                float pushStrength = 0.1f;

                // 아래 방향에서 밀리는 경우 → 위로 이동
                if (penetrationDir.y <= 0.1f)
                {
                    transform.position += Vector3.up * pushStrength;
                    rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0.5f);
                }
            }
        }
    }
}
