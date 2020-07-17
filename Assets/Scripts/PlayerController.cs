using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    public Rigidbody rb;

    [Header("Movement")]
    public float speed = 5f;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);

        rb.velocity = velocity;
    }
}
