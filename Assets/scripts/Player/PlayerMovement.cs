using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDown;
    public bool IFrame = false;
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
                coolDown = dashCoolDown;
                StartCoroutine(Dash(x, z));
            }
        }
        else
            controller.Move(playerSpeed * Time.deltaTime * move);
    }

    IEnumerator Dash(float x, float z)
    {
        float start = Time.time;
        IFrame = true;

        while (Time.time < start + dashTime)
        {
            Vector3 dashing = dashSpeed * x * transform.right + z * dashSpeed * transform.forward;
            controller.Move(dashing * Time.deltaTime);
            yield return null;
        }

        IFrame = false;
    }
}
