﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private bool canJump;
    private Rigidbody rb;
    public Animator anims;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anims.SetFloat("horizontal_float", Input.GetAxis("Horizontal"));
        anims.SetFloat("vertical_float", Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift)) {
            anims.SetBool("Shift", true);
        }
        else {
            anims.SetBool("Shift", false);
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            anims.SetBool("Attack1", true);
        }
        else {
            anims.SetBool("Attack1", false);
        }
        if (Input.GetKey(KeyCode.Mouse1)) {
            anims.SetBool("Attack2", true);
        }
        else { 
            anims.SetBool("Attack2", false);
        }
        if (Input.GetKey(KeyCode.Q)) {
            anims.SetBool("Attack3", true);
        }
        else {
            anims.SetBool("Attack3", false);
        }
        if (Input.GetKey(KeyCode.Space)) {
            canJump = true;
            anims.SetBool("IsJump", true);
        }
    }
    void FixedUpdate() {
        if (canJump) {
            canJump = false;
            rb.AddForce(Vector3.up * 20);
            anims.SetBool("IsJump", false);
        }
    }
}
