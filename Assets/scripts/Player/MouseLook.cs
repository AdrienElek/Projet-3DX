using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private Transform playerBody;
    [SerializeField] private PlayerStats stats;

    private float xRot;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * stats.MouseSpeedX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * stats.MouseSpeedY * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90); //limit up and down
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}