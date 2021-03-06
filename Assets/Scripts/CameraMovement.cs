﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Mouse_Sensitivity = 100f;
    public Transform playerBody;
    public float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Mouse_Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Mouse_Sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        // transform.position.y = Mathf.Lerp(transform.position.y, playerBody.position.y, Time.deltaTime * 10);
    }
}
