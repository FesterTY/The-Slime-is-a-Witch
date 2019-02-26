using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(HealthManager))]
public class Player : Destructible
{

    PlayerController controller;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    LongRangedController longRanged;
    Animator anim;
    HealthManager healthManager;

    bool isMoving;
    bool isGrounded;
    bool shouldBeJumping;
    bool isFacingLeft;

    float moveVelocity;
    float moveX;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayerMask;

    public float jumpForce = 5f;
    public float moveSpeed = 350f;

    public int extraJumps = 1;
    private int extraJumpsCounter = 0;

    public float timeBetweenJump = 0.35f;
    float timeBetweenJumpCounter;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        longRanged = GetComponent<LongRangedController>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        /* MOVEMENTS */
        isMoving = false;
        moveX = Input.GetAxisRaw("Horizontal");
        if (moveX != 0)
        {
            isMoving = true;
        }

        moveVelocity = moveX * moveSpeed;

        // Check to see if player is on the ground
        CheckIsGrounded(groundCheck.position, checkRadius, groundLayerMask, out isGrounded);

        // Check if player should be flipped
        CheckFlip();

        timeBetweenJumpCounter -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeBetweenJumpCounter <= 0)
        {
            shouldBeJumping = true;
            timeBetweenJumpCounter = timeBetweenJump;
        }

        anim.SetBool("isMoving", isMoving);

        longRanged.Shoot("Shoot");
    }

    private void FixedUpdate()
    {
        if (shouldBeJumping && (isGrounded || extraJumpsCounter > 0))
        {
            controller.Jump(jumpForce, isGrounded, ref extraJumpsCounter, ref extraJumps);
            shouldBeJumping = false;
        }

        controller.Move(moveVelocity * Time.fixedDeltaTime);
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;

        transform.Rotate(Vector3.up * 180f);
    }

    void CheckFlip()
    {
        // player is NOT facing left, but is moving left
        if (!isFacingLeft && moveX < 0)
        {
            Flip();
        }
        // player is facing left, but is moving right
        else if (isFacingLeft && moveX > 0)
        {
            Flip();
        }
    }

    private void CheckIsGrounded(Vector2 _circlePosition, float _circleRadius, LayerMask _whatToCheck, out bool _isGrounded)
    {
        _isGrounded = Physics2D.OverlapCircle(_circlePosition, _circleRadius, _whatToCheck);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            healthManager.Harm(1f);

            if (healthManager.currentHealth > 0)
            {
                StartCoroutine(ObjectFlash());
            }
        }
    }
}
