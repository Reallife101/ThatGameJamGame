using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;

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

        // Convert LOCAL → WORLD based on player rotation
        Vector3 worldMove = transform.TransformDirection(move);

        worldMove.y = 0;

        worldMove *= walkSpeed;

        controller.Move(worldMove * Time.deltaTime);
    }

    private void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }
}
