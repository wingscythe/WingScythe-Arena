using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    public Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    [Header("Dashing")]
    public float dashSpeed = 50f;
    public float dashTime = 0.05f;
    public float dashRecoveryTime = 0.5f;

    [Header("State")]
    public int state = 0;
    public int args = 0;
    public float speed = 5f;
    public float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * State Controller
         * 
         * 0: Default
         * 1: Recovery Frames
         * 2: Dash Frames
         */
        switch (state) {
            case 2:
                if(args == 1) {
                    //First Dash Frame
                    cooldown = dashTime;
                    speed = dashSpeed;
                    args = 0;
                }
                Dash();
                break;
            case 1:
                RecoveryFrames();
                break;
            default:
                InputUpdate();
                Movement();
                Transition();
                break;
        }
    }

    void Transition() {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            state = 2;
            args = 1;
        }
    }

    void Dash() {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0) {
            state = 1;
            speed = 0;
            cooldown = dashRecoveryTime;
        }

        Movement();
    }

    void Movement() {
        Vector3 velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        rb.velocity = velocity;
    }

    void InputUpdate() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void RecoveryFrames() {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0) {
            ResetState();
        }
    }

    void ResetState() {
        state = 0;
        args = 0;
        speed = moveSpeed;
        cooldown = 0;
    }
}
