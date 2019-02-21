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

    public float timeBetweenJump = 1f;
    float timeBetweenJumpCounter;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveVelocity = moveX * moveSpeed;

        // Check to see if player is on the ground
        CheckIsGrounded(groundCheck.position, checkRadius, groundLayerMask, out isGrounded);

        // Check if player should be flipped
        CheckFlip(moveX);

        InputToJump();
    }

    private void FixedUpdate()
    {
        if (shouldBeJumping == true && isGrounded == true)
        {
            controller.Jump(jumpForce);
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

    public void InputToJump()
    {
        timeBetweenJumpCounter -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeBetweenJumpCounter <= 0 && isGrounded == true)
            {
                shouldBeJumping = true;
                timeBetweenJumpCounter = timeBetweenJump;
            }
        }
    }
}
