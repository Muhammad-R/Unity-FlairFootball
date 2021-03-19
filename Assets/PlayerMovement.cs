using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    public float jumpHeight = 2f;

    private float groundDistance = 0.4f;
    private float gravity = -19.62f;
    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
