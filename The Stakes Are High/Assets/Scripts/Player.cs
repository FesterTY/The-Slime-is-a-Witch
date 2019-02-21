using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    PlayerController controller;
    Vector2 moveVelocity;

    public float moveSpeed = 5f;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput.normalized * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {

        controller.Move(moveVelocity);
    }
}
