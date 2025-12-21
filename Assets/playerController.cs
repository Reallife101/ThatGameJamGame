using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;

    [Header("camera")]
    [SerializeField] private Transform cam;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("Input")]
    private float moveInput;
    private float turnInput;

    private void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController > ();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);

        // Only rotate if there is movement input
        if (move.sqrMagnitude > 0.01f)
        {
            RotateTowardsCamera();
        }

        // Convert LOCAL → WORLD based on player rotation
        Vector3 worldMove = cam.TransformDirection(move);

        worldMove.y = 0;

        worldMove *= walkSpeed;

        controller.Move(worldMove * Time.deltaTime);
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
}
