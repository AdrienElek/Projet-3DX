using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField] private float turnSpeed = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(playerSpeed * Time.deltaTime * move);
        /*
        float TurnInput = Input.GetAxis("Horizontal");
        if (TurnInput != 0f)
        {
            float angle = Mathf.Clamp(TurnInput, -1f, 1f) * turnSpeed;
            transform.Rotate(Vector3.up, Time.fixedDeltaTime * angle);
        }
        float ForwardInput = Input.GetAxis("Vertical");
        if (!Mathf.Approximately(ForwardInput, 0f))
        {
            Vector3 verticalVelocity = Vector3.Project(rb.velocity, Vector3.up);
            rb.velocity = verticalVelocity + transform.forward * Mathf.Clamp(ForwardInput, -1f, 1f) * playerSpeed / 2f;
        }*/
    }
}
