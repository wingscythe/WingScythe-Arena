using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    public Animator anims;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            anims.SetBool("Attack1", true);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Attack2");
            anims.SetBool("Attack2", true);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Attack3");
            anims.SetBool("Attack3", true);
        }
        anims.SetFloat("Horizontal_Float", horizontalInput);
        anims.SetFloat("Vertical_Float", verticalInput);
    }
}
