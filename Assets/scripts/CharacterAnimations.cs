using UnityEngine;
using UnityEngine.InputSystem;
// This component requires an Animator and CharacterController
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterAnimations : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f; // Speed when walking
    public float runSpeed = 10f; // Speed when running
    private float moveSpeed; // Current movement speed
    private bool isRunning = false; // Tracks whether the player is sprinting
    private CharacterController controller;
    private Animator characterAnimator;
    private Vector2 moveInput; // Input value from WASD / Joystick
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();

        moveSpeed = walkSpeed; // Start with walking speed
    }
    private void Update()
    {
        // Convert the 2D input to a 3D movement direction (X = left-right, Z = forward-back)
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        // Apply movement to the CharacterController
        controller.Move(move * moveSpeed * Time.deltaTime);
        // Calculate movement magnitude (0 = idle, 1 = full movement)
        float speedPercent = moveInput.magnitude;
        // Character is walking if:
        // 1) They have input (move.magnitude > 0.1)
        // 2) They are NOT running
        bool isWalking = move.magnitude > 0.1f && !isRunning;
        // Update Animator parameters
        characterAnimator.SetBool("isWalking", isWalking);
        characterAnimator.SetBool("isRunning", isRunning);
        // Debug only (can be removed)
        Debug.Log("Speed Input Value: " + speedPercent);
    }
    // New Input System movement callback
    public void OnMove(InputValue movementValue)
    {
        // Read the 2D movement input from player
        moveInput = movementValue.Get<Vector2>();
    }
    // Jump input callback
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            // Only plays animation – no physics jump included here
            characterAnimator.SetTrigger("Jump");
        }
    }
    // Sprint callback (Shift key usually)
    public void OnSprint(InputValue value)
    {
        if (value.isPressed)
        {
            // Switch to running
            moveSpeed = runSpeed;
            isRunning = true;
        }
        else
        {
            // Return to walking
            moveSpeed = walkSpeed;
            isRunning = false;
        }
        Debug.Log("Sprint toggled");
    }
}

