using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    private Rigidbody rb;
    
    public float sensitive = 100f;
    public float rotationX;
    public float rotationY;
    private Camera cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        cam = Camera.main;
    }

    private void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveX * sensitive * Time.deltaTime;
        rotationX -= mouseMoveY * sensitive * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -80.0f, 70.0f);

        cam.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}