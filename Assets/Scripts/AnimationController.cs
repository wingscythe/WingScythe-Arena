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
        anims.SetFloat("horizontal_float", Input.GetAxis("Horizontal"));
        anims.SetFloat("vertical_float", Input.GetAxis("Vertical"));
    }
}
