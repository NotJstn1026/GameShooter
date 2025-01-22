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
    public Transform groundCheckTransform; // Empty GameObject for ground check
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private GroundCheck groundCheck;
    private Vector3 velocity;
    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("No CharacterController found on the player object! Please add and configure one in the Inspector.");
            enabled = false; // Disable the script to prevent further issues.
            return;
        }

        cameraTransform = Camera.main?.transform;
        if (cameraTransform == null)
        {
            Debug.LogError("No Main Camera found in the scene!");
            enabled = false;
            return;
        }

        if (groundCheckTransform == null)
        {
            Debug.LogError("GroundCheck Transform is not assigned in the Inspector!");
            enabled = false;
            return;
        }

        groundCheck = new GroundCheck(groundCheckTransform, groundCheckRadius, groundLayer);

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck is not initialized!");
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

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









