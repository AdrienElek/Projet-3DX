using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerManager manager;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private bool isGrounded;
    private Rigidbody rb;
    private CharacterController controller;
    private float coolDown = 0;
    private Vector3 velocity;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, stats.GroundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (coolDown != 0)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
                coolDown = 0;
        }
            
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown("space"))
        {
            manager.TakeDamage(30);
            if (coolDown == 0)
            {
                coolDown = stats.DashCoolDown;
                StartCoroutine(Dash(x, z));
            }
        }
        else
            controller.Move(stats.PlayerSpeed * Time.deltaTime * move);

        if (Input.GetKeyDown("c") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(stats.JumpHeight * -2f * stats.Gravity);
        } 
        velocity.y += stats.Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Dash(float x, float z)
    {
        float start = Time.time;
        stats.IsInvincible = true;

        while (Time.time < start + stats.DashTime)
        {
            Vector3 dashing = stats.DashSpeed * x * transform.right + z * stats.DashSpeed * transform.forward;
            controller.Move(dashing * Time.deltaTime);
            yield return null;
        }

        stats.IsInvincible = false;
    }
}
