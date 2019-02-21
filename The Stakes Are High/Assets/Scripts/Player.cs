using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    PlayerController controller;
    Vector2 moveVelocity;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);

        // Check if player should be flipped
        CheckFlip(moveInput);
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(moveVelocity * Time.fixedDeltaTime);
    }

    void Flip(bool isFacingLeft)
    {
        // Enable flipping in X direction depending on the boolean given
        spriteRenderer.flipX = isFacingLeft;
    }

    void CheckFlip(Vector2 moveInput)
    {
        // If the player is going right
        if (moveInput.x > 0)
        {
            Flip(false); // Face right
        }
        // If the player is going left
        else if (moveInput.x < 0)
        {
            Flip(true); // Face left
        }
    }
}
