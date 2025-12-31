using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    private Animator anim;

    [Header("camera")]
    [SerializeField] private Transform cam;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("Gravity Settings")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundedPull = -2f;

    [Header("Input")]
    private float moveInput;
    private float turnInput;

    private float verticalVelocity;

    private bool canMove = true;

    private void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController > ();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
        ApplyGravity();
    }

    private void GroundMovement()
    {
        if (!canMove)
            return;
        Vector3 input = new Vector3(turnInput, 0f, moveInput);

        // Convert input to camera-relative movement
        Vector3 worldMove = cam.TransformDirection(input);
        worldMove.y = 0f;

        // Rotate player toward movement direction
        if (worldMove.sqrMagnitude > 0.01f)
        {
            RotateTowardsMoveDirection(worldMove);
        }

        worldMove *= walkSpeed;
        controller.Move(worldMove * Time.deltaTime);

        // Apply Walk/Idle Animation
        anim.SetFloat("moveSpeed", worldMove.magnitude);
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = groundedPull;
        }

        verticalVelocity += gravity * Time.deltaTime;

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    private void RotateTowardsMoveDirection(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
    private void RotateTowardsCamera()
    {
        // Camera forward flattened on Y
        Vector3 camForward = cam.forward;
        camForward.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(camForward);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}

