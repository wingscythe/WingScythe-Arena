using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    public Rigidbody rb;
    public Animator anims;
    public Transform PeetL;
    public Transform PeetR;
    public LayerMask whatIsGround;

    //TODO: Create Attack Automation
    [Header("Attack")]
    public float attackStartUp = 0.1f;
    public float attackActive = 0.5f;
    public float attackRecovery = 0.2f;

    [Header("Movement")]
    public float moveSpeed = 5f;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    [Header("Dashing")]
    public float dashStartUp = 0.1f;
    public float dashSpeed = 50f;
    public float dashTime = 0.1f;
    public float dashRecoveryTime = 0.2f;

    [Header("Jumping")]
    public float checkRadius = 0.01f;

    [Header("State")]
    public int state = 0;
    public int args = 0;
    public float speed = 5f;
    public float cooldown = 0f;
    public bool canJump = false;
    public bool grounded = true;

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
         * 3: Attack
         * 4: StartUp
         */
        switch (state) {
            case 4: 
                StartUpFrames();
                break;
            case 3:
                if(args == 0){
                    //First frame after startup
                    cooldown = attackActive;
                    args = 1;
                }
                Attack();
                break;
            case 2:
                if(args == 1) {
                    //First Dash Frame
                    cooldown = dashTime;
                    speed = dashSpeed;
                    anims.SetBool("Shift", true);
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

    void ResetAnimation(){
        anims.SetBool("Shift", false);
        anims.SetBool("Attack1", false);
        anims.SetBool("Attack2", false);
        anims.SetBool("Attack3", false);
    }

    void Transition() {
        grounded = Physics.OverlapSphere(PeetL.position, checkRadius, whatIsGround).Length > 0 && Physics.OverlapSphere(PeetR.position, checkRadius, whatIsGround).Length > 0;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            state = 2;
            args = 1;
        } else if(Input.GetAxisRaw("Fire1") != 0){
            state = 4;
            cooldown = attackStartUp;
            args = 3;
            anims.SetBool("Attack1", true); //Automate these
        } else if(Input.GetAxisRaw("Fire2") != 0){
            state = 4;
            cooldown = attackStartUp;
            args = 3;
            anims.SetBool("Attack2", true);
        } else if(Input.GetKey(KeyCode.Q)) {
            state = 4;
            cooldown = attackStartUp;
            args = 3;
            anims.SetBool("Attack3", true);
        } else if (Input.GetKey(KeyCode.Space) && grounded) {
            canJump = true;
            anims.SetBool("IsJump", true);
        } else {
            ResetAnimation();
        }
    }

    void Attack(){
        cooldown -= Time.deltaTime;

        if(cooldown <= 0) {
            cooldown = attackRecovery;
            state = 1;
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
        Vector3 velocity = (transform.right * horizontalInput + transform.forward * verticalInput) * speed;;
        rb.velocity = velocity;

        if (canJump) {
            canJump = false;
            rb.AddForce(Vector3.up * 20);
            anims.SetBool("IsJump", false);
        }
    }

    void InputUpdate() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        anims.SetFloat("horizontal_float", horizontalInput);
        anims.SetFloat("vertical_float", verticalInput);
    }

    void RecoveryFrames() {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0) {
            ResetState();
        }
    }

    void StartUpFrames(){
        cooldown -= Time.deltaTime;

        if(cooldown <= 0) {
            state = args;
            args = 0;
        }
    }

    void ResetState() {
        state = 0;
        args = 0;
        speed = moveSpeed;
        cooldown = 0;
    }
}
