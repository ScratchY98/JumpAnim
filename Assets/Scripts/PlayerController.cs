using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header ("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 500f;
    private bool isJumping;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundCheckCollisionsLayer;
    [HideInInspector]public bool isGrounded;

    [Header("Components's Reference")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D playerRb;

    private void Update()
    {
        // Get the Input
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Checks if the player touch the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckCollisionsLayer);

        // Move the player
        playerRb.velocity = new Vector2(horizontalMovement * moveSpeed, playerRb.velocity.y);

        // Flip the player
        if (playerRb.velocity.x != 0)
            spriteRenderer.flipX = playerRb.velocity.x > 0 ? false : true;

        // Look if the player press the jump button and if he touch the ground
        isJumping = (Input.GetButtonUp("Jump") && isGrounded);

        if (isJumping)
        {
            // Jumping
            playerRb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

    }

    private void OnDrawGizmos()
    {
        // Do GIzmos for Check Gizmos in inspector
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}