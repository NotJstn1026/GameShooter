using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;

    [Header("Ground Check Settings")]
    public Transform groundCheckTransform;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private GroundCheck groundCheck;
    private Vector3 velocity;
    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        // Initialize required components
        controller = GetComponent<CharacterController>();
        if (!controller)
        {
            Debug.LogError("No CharacterController found on the Player!");
        }

        cameraTransform = Camera.main.transform;

        // Initialize GroundCheck
        groundCheck = new GroundCheck(groundCheckTransform, groundCheckRadius, groundLayer);

        // Lock cursor for mouse look
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        // Mouse input for looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        // WASD input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Debugging movement
        Debug.Log($"Movement Vector: {move}");

        // Gravity and jumping
        if (groundCheck.IsGrounded())
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}








