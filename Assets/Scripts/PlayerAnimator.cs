using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimator : MonoBehaviour
{
    [Header ("Components's Reference")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;

    private float previousYPosition;

    private void Start()
    {
        // Get the previous Y position
        previousYPosition = transform.position.y;
    }

    private void Update()
    {
        // Get the current Y position
        float currentYPosition = transform.position.y;

        // Get the Y velocity 
        float yVelocity = currentYPosition - previousYPosition;

        // Set the animations
        animator.SetFloat("VelocityY", yVelocity);
        animator.SetBool("IsGrounded", playerController.isGrounded);

        // Get the previous Y position
        previousYPosition = currentYPosition;
    }
}
