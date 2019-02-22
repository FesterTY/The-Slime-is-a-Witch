using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    PlayerController controller;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    bool shouldBeJumping;

    float moveVelocity;
    float moveX;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayerMask;

    public float jumpForce = 5f;
    public float moveSpeed = 350f;

    public int extraJumps = 1;
    private int extraJumpsCounter = 0;

    public float timeBetweenJump = 0.5f;
    float timeBetweenJumpCounter;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        /* MOVEMENTS */
        moveX = Input.GetAxisRaw("Horizontal");
        moveVelocity = moveX * moveSpeed;

        // Check to see if player is on the ground
        CheckIsGrounded(groundCheck.position, checkRadius, groundLayerMask, out isGrounded);

        // Check if player should be flipped
        CheckFlip(moveX);

        timeBetweenJumpCounter -= Time.deltaTime;
        if (Input.GetAxisRaw("Jump") > 0 && timeBetweenJumpCounter <= 0)
        {
            shouldBeJumping = true;
            timeBetweenJumpCounter = timeBetweenJump;
        }
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

    void Flip(bool isFacingLeft)
    {
        // Enable flipping in X direction depending on the boolean given
        spriteRenderer.flipX = isFacingLeft;
    }

    void CheckFlip(float moveX)
    {
        // If the player is going right
        if (moveX > 0)
        {
            Flip(false); // Face right
        }
        // If the player is going left
        else if (moveX < 0)
        {
            Flip(true); // Face left
        }
    }

    private void CheckIsGrounded(Vector2 _circlePosition, float _circleRadius, LayerMask _whatToCheck, out bool _isGrounded)
    {
        _isGrounded = Physics2D.OverlapCircle(_circlePosition, _circleRadius, _whatToCheck);
    }
}
