using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    private Rigidbody rb;
    private CharacterController controller;
    private float coolDown = 0;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
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
            if (coolDown == 0)
            {
                coolDown = stats.DashCoolDown;
                StartCoroutine(Dash(x, z));
            }
        }
        else
            controller.Move(stats.PlayerSpeed * Time.deltaTime * move);
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
